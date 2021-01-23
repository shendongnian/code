    public class RowImageVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int rowNumber = (int)values[0];
            int activeRow = (int)values[1];
            return rowNumber == activeRow ? Visibility.Visible : Visibility.Hidden;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
