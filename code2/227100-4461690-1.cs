    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Ellipse e = parameter as Ellipse;
            Double d = (Double)value;
            return d + (e.ActualWidth / 2);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Ellipse e = parameter as Ellipse;
            Double d = (Double)value;
            return d - (e.ActualWidth / 2);
        }
    }
