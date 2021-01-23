    public class FruitToColorConverter : IValueConverter
    {
      private SolidColorBrush Default = new SolidColorBrush(Colors.Black);
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if (value == null || (!(value is string))) { return Default; }
        switch (value as string)
        {
          case "Apple":
            return new SolidColorBrush(Colors.Red);
          case "BlueBerry":
            return new SolidColorBrush(Colors.Blue);
          default:
            return Default;
            ......
