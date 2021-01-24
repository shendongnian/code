    public class ImageSourceConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if(string.IsNullOrWhiteSpace(value.ToString())){
            
               return "DefaultImage";
           }
          return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
