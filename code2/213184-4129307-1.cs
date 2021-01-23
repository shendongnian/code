    [ValueConversion(typeof(StateValue), typeof(Color))]
    public class StateValueColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is StateValue))
                throw ArgumentException("value not of type StateValue");
            StateValue sv = (StateValue)value;
            //sanity checks
            if(sv == StateValue.Player)
                return Colors.Red;
            //etc
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           Color c = (value as Color);
           if(c == Colors.Red)
             return StateValue.Player;
           //etc
        }
    }
