    public class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Cast<bool>().Any(b => b);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object[] returnValue = new object[targetTypes.Length];
            for (int i = 0; i < targetTypes.Length; i++)
            {
                returnValue[i] = (bool)value;
            }
            return returnValue;
        }
    }
