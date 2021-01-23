    public class BlockingConverter : IValueConverter
    {
        public object lastValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return lastValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            lastValue = value;
            return value;
        }
    }
