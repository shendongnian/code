    public class DoubleToString: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dbl = (double) value;
    
            return $"{dbl} cm";           
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Double.Parse(Regex.Match(value.ToString(), "[\d.]+").Value);    
        }
    }
