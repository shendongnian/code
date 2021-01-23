    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (DateTime)value;
            if (str.IsNullOrWhitespace())
            {
                return "No Data";
            }
            return str;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ... //An empty implementation I expect...
        }
    }
