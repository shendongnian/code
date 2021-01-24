    public class Number1Number2Converter : BindableObject, IValueConverter {
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(int), typeof(Number1Number2Converter), null);
    
        public int Value {
            get {
                return (int)GetValue(ValueProperty);
            }
            set {
                SetValue(ValueProperty, value);
            }
        }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is int number1)
            {
                 var number2 = Value;
            }
            return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
