    public class boolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                // Cast
                var valueCast = (bool)value;
    
                // Transform
                valueCast = !valueCast;
                
                // Return
                return valueCast;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                // Most of the time you are not handling bi-directional converts, but you need
                // to implement the contract of IValueCoverter fully regardless.
                throw new NotImplementedException();
            }
        }
