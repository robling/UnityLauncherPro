﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace UnityLauncherPro
{
    public class EditorInfo
    {
        public string Path;
        public string Version;

        public override string ToString()
        {
            return $"{Version}({Path})";
        }

        public static EditorInfo FromString(string s)
        {
            var parts = s.Split('(');
            if (parts.Length != 2)
                return null;

            return new EditorInfo
            {
                Path = parts[1].Trim('(', ')'),
                Version = parts[0]
            };
        }
    }
    public class Project : IValueConverter
    {
        public string Title { set; get; }
        public string Version { set; get; }
        public string Path { set; get; }
        public DateTime? Modified { set; get; }
        public string Arguments { set; get; }
        public string GITBranch { set; get; } // TODO rename to Branch
        //public string TargetPlatform { set; get; }
        public string TargetPlatform { set; get; } // TODO rename to Platform
        public string[] TargetPlatforms { set; get; }
        public string Editor { set; get; } // TODO rename to Platform
        public string[] Editors { set; get; }
        public bool folderExists { set; get; }
        public string SRP { set; get; } // Scriptable Render Pipeline, TODO add version info?

        // WPF keeps calling this method from AppendFormatHelper, GetNameCore..? not sure if need to return something else or default would be faster?
        public override string ToString()
        {
            return Path;
        }

        // for debugging
        //public override string ToString()
        //{
        //    return $"{Title} {Version} {Path} {Modified} {Arguments} {GITBranch} {TargetPlatform}";
        //}

        // change datagrid colors based on value using converter https://stackoverflow.com/a/5551986/5452781
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}