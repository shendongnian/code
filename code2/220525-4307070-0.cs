      public class MyEnumToStringConverter : IValueConverter
      {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value.ToString();
         }
    
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return (MyEnum) Enum.Parse( typeof ( MyEnum ), value.ToString(), true );
         }
      }
