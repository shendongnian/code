     public class FloorToEnableConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    if (value == null)
                        throw new ArgumentException("value cannot be null");
        
                    if ((int)value == 1)
                        return false;
                    if ((int)value == 2)
                        return true;
        
                    // for all other values disable
                    return false;
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
    }
