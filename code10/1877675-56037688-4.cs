      public class StringNullOrEmptyBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                return !string.IsNullOrEmpty($"{value}");
           
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
                throw new NotImplementedException();
        }
    }
  
