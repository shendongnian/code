    public class LogScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double x = (int)value;
            return Math.Log(x);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double x = (double)value;
            return (int)Math.Exp(x);
        }
    }
