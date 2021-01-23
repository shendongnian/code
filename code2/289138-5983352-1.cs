    public class NameValueMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
    
            var parameters = (object[])values;
            return new NameValueConverterResult 
                            { 
                               Name = (string)parameters[0], 
                               Value = parameters[1] 
                            };
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
