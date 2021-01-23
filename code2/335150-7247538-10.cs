    public class ArtistNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            try
            {
                return values[0].ToString().StartsWith(values[1].ToString());
            }
            catch
            {
                return false;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
