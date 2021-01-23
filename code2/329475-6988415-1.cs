    public class makeBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int theValueToConvertToColor = (int)value;
            if (theValueToConvertToColor > 10 && theValueToConvertToColor <= 20)
            {
                return Brushes.Red;
            }
            if (theValueToConvertToColor > 20 && theValueToConvertToColor <= 30)
            {
                return Brushes.Blue;
            }
            //More ifs...
            else return Brushes.Green;            
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
