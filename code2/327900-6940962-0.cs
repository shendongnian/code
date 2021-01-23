    public class StringToImageConverter : IValueConverter
    {
    
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        string url = value as string;
        Uri uri = new Uri(url);
        return new BitmapImage(uri);
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
