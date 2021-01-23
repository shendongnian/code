    public class BrushConverter : IMultiValueConverter
    {
        public object Converter(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(
                Color.FromArgb(255, Convert.ToByte(values[0]), 
                    Convert.ToByte(values[1]), Convert.ToByte(values[2])));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // this can be implemented fairly easily
            throw new NotSupportedException();
        }
    }
