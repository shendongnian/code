    public class GridLengthValueConverter : IValueConverter
    {
        GridLengthConverter _converter = new GridLengthConverter();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return _converter.ConvertFrom(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return _converter.ConvertTo(value, targetType);
        }
    }
