    [ValueConversion(typeof(BitmapSource), typeof(string))]
    public class  BitmapSourceToFilenameConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if (value is BitmapSource bitmapSource)
          return bitmapSource.UriSource.AbsolutePath;
        return Binding.DoNothing;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
