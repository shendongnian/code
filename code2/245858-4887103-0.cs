    public class IsGreaterThanConverter : IValueConverter {
        public static readonly IValueConverter Instance = new IsGreaterThanConverter();
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            int intValue = (int) value;
            int compareToValue = (int) parameter;
    
            return intValue > compareToValue;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
