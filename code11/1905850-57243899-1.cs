    public class NameMultiValueConverter : IMultiValueConverter
    {
      public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return String.Format("{0} {1}", values[0], values[1]);
      }
    
      /// <inheritdoc />
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
