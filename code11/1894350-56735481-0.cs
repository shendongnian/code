    // error handling and boilerplate omitted
    public class ErrorConverter : IValueConverter
    {
        public object Convert (object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return ((ErrorCollection) value)[(string)parameter] ;
        }
    }
