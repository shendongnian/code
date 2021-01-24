     public class ByteArrayToImageSourceConverter : IValueConverter
     {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        ImageSource retSource = null;
        if (value != null)
        {
            byte[] imageAsBytes = (byte[])value;
            var stream = new MemoryStream(imageAsBytes);
            retSource = ImageSource.FromStream(() => stream);
        }
        return retSource;
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
      }
    }
