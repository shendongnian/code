    namespace Example
    {
        public class HMLConverter:IValueConverter
        {
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string val = value.ToString();
                int ret = 0;
                switch (val.ToLower())
                {
                    case "hi":
                        ret = 100;
                        break;
                    case "lo":
                        ret = 0;
                        break;
                    case "med":
                        ret=50;
                        break;
                    default:
                        throw new NotSupportedException("Value " + val + " is not supported");
                }
                return ret;
               
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
