    public class RgbToBrushConverter : IMultiValueConverter
    {
        public RgbToBrushConverter()
        {
        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var x = ExtractColorFrom(values);
            return new SolidColorBrush(x);
        }
        private Color ExtractColorFrom(object[] values)
        {
            byte red = System.Convert.ToByte((double)values[0]);
            byte green = System.Convert.ToByte((double)values[1]);
            byte blue = System.Convert.ToByte((double)values[2]);
            return Color.FromRgb(red, green, blue);
        }
        ///MUST!!!!!
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
