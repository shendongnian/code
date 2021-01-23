    public class OpacityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isMouseOver = (bool)values[0];
            bool selected = (bool)values[1];
            if (selected == true)
            {
                return 1.0;
            }
            else if (isMouseOver == true)
            {
                return 0.5;
            }
            return 0.0;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
