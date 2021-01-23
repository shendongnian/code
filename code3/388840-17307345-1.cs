    public class XmlStringConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            string valueAsString = value as string;
            if (string.IsNullOrEmpty(valueAsString))
            {
                return value;
            }
    
            valueAsString = valueAsString.Replace("\\r\\n", "\r\n");
            return valueAsString;
        }
    
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
