    public class ConverterToggleButtonCheck : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;
            return ((string)value).Trim() == ((string)parameter).Trim();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;
            if ((bool)value == true)
                return parameter;
            return "";
        }
    }
