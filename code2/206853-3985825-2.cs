    [ValueConversion(typeof(int), typeof(SolidColorBrush))]
    public class QualityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Cast value
            int intValue = (int) value;
    
            if (intValue == 1)
                return new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
    
            return new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("TwoWay binding not supported!");
        }
    }
