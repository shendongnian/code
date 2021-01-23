    public class AuthenticationToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AuthenticationEnum authenticationEnum = (AuthenticationEnum)parameter;
            //...
        }
    }
