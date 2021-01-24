    public class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return BitmapFrame.Create(new System.IO.MemoryStream(System.Convert.FromBase64String((string)value)), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
