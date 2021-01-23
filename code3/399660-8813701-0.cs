    public class ObjectToTooltipConverter: IValueConverter {
   
     public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if(value is Decimal)
      {
        return "The value was a decimal";
      }
      if(value is String)
      {
        return "The value was a string";
}
