    public class Number1Number2Converter : IValueConverter {    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is Item item)
            {
                 var number1 = item.Number1;
                 var number2 = item.Number2,
            }
            return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
