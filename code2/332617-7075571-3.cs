        public class TextConverter : IValueConverter {
            #region IValueConverter Members
    
            public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                string input = (string)value;
                char[] sep = {'/'};
                string[] iparray = input.Split (sep);
                int index = Int32.Parse((string)parameter);
    
                return iparray[index];
            }
    
            public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException ();
            }
    
            #endregion
        }
