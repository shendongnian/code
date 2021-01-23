    public class boolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if(!(value is bool))
                   throw new Exception("invalid type");
                return ((bool)value)? Visibility.Visible: Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                // Most of the time you are not handling bi-directional converts, but you need
                // to implement the contract of IValueCoverter fully regardless.
                throw new NotImplementedException();
            }
        }
