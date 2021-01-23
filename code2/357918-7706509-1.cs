    public class MyConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values != null && values[0] is bool && values[1] is MyViewModel)
                {
                    ((MyViewModel)values[1]).MyBoolProperty = (bool)values[0];
                    return (bool)values[0];
                }
    
                return DependencyProperty.UnsetValue;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
