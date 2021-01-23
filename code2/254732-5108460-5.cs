    public class PointXConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double progressBarValue = (double)value;
            double yValue = System.Convert.ToDouble(parameter);
            return new Point(progressBarValue, yValue);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
