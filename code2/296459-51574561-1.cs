    public class ImageFormatValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ImageFormat format)
            {
                return GetString(format);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                return Enum.Parse(typeof(ImageFormat), s.Substring(0, s.IndexOf(':')));
            }
            return null;
        }
        public string[] Strings => GetStrings();
        public static string GetString(ImageFormat format)
        {
            return format.ToString() + ": " + GetDescription(format);
        }
        public static string GetDescription(ImageFormat format)
        {
            return format.GetType().GetMember(format.ToString())[0].GetCustomAttribute<DescriptionAttribute>().Description;
        }
        public static string[] GetStrings()
        {
            List<string> list = new List<string>();
            foreach (ImageFormat format in Enum.GetValues(typeof(ImageFormat)))
            {
                list.Add(GetString(format));
            }
            return list.ToArray();
        }
    }
