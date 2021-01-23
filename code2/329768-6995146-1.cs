    public class ThicknessMaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Thickness thickness = (Thickness)value;
            double horizontalMax = Math.Max(thickness.Left, thickness.Right);
            double verticalMax = Math.Max(thickness.Top, thickness.Bottom);
            return Math.Max(horizontalMax, verticalMax);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
