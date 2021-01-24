     public class CellConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach(object value in values)
            {
                if (value == DependencyProperty.UnsetValue)
                    continue;
                else
                    return value;
            }
            return null;
        }       
        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
       
    }
