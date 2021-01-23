    public class StringToUpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).ToUpper();
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
        }
    }
