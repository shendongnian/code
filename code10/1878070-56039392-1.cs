    public class NameToBrushConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        string input = value as string;
        switch (input)
        {
            case "Smith":
                return Brushes.LightGreen;
            case "Willam":
                return Brushes.LightPink;
            default:
                return DependencyProperty.UnsetValue;
        }
     }
     public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
     {
        throw new NotSupportedException();
     } }
