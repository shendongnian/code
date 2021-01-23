    public sealed class StringFormatConverter : IValueConverter
    {
        private static readonly StringFormatConverter instance = new StringFormatConverter();
        public static StringFormatConverter Instance
        {
            get
            {
                return instance;
            }
        }
        private StringFormatConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(culture, (string)parameter, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
