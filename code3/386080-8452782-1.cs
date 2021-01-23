    public class StringToEnabledConverter : IValueConverter
        {
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var val = value as string;
                if (val == null)
                    throw new ArgumentException("value must be a string.");
    
                return !string.IsNullOrEmpty(val);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
