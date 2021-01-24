    public class SizePercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) 
                return 0:
            if (parameter == null)
                return (double)value;
            var split = parameter.ToString().Split('.');
            var parameterDouble = double.Parse(split[0]) + double.Parse(split[1]) / Math.Pow(10, split[1].Length);
            return (double)value * parameterDouble;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Don't need to implement this
            return null;
        }
