    [ValueConversion(typeof(List<string>), typeof(string))]
    public class ListToStringConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return value is IEnumerable<string> stringCollection 
          ? string.Join(";", stringCollection)
          : Binding.DoNothing;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        string[] stringSeparators = new string[] {";", " "};
        return value is string stringValue && stringValue.LastIndexOfAny(stringSeparators) < stringValue.Length - 1 
          ? stringValue.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList() 
          : new List<string>();
          : Binding.DoNothing;
      }
    }
