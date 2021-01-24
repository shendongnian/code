    public class ListToStringConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {    
            return String.Join(", ", ((List<string>)value).ToArray());
        }
    
        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
