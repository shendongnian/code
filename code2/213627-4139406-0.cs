    class NegativeValueConverter : IValueConverter
    {
      object Convert(object value, ...)
      {
        return -System.Convert.ToDouble(value);
      }
    
      object ConvertBack(object value, ...)
      {
        return -System.Convert.ToDouble(value);
      }
    }
