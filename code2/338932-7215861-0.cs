    public class UrlPrefixConverter : IValueConverter
    {
         public string Prefix {get; set;}
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            { 
                return new Uri(Prefix + value.ToString(), UriKind.Absolute);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
