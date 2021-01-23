    public class ArtistNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            try
            {
                return value.ToString().StartsWith(parameter.ToString());
            }
            catch
            {
                return false;
            }
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
