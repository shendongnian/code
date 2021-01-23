    public class ZoomToWidthConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                Double imgOriginalWidth = 24;
                return imgOriginalWidth / System.Convert.ToDouble(value);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                Double imgOriginalWidth = 24;
                return System.Convert.ToDouble(value) * imgOriginalWidth;
            }
    }
