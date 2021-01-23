    public class AndNotConverter : IMultiValueConverter
    {
      public object Convert(object[] values, Type targetType, object parameter, 
          System.Globalization.CultureInfo culture)
      {
          return (bool)values[0] && !((bool)values[1]);
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
          System.Globalization.CultureInfo culture)
      {
          throw new NotImplementedException();
      }
    }
