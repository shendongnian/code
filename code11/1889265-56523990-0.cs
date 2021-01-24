    public class TimeSpanFormatConverter : IValueConverter
    {
        public string StringFormat { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string result = "";
            if (value == null)
            {
                return null;
            }
    
            if (parameter == null)
            {
                return value;
            }
    
            if (value is TimeSpan timeSpan)
            {
                try
                {
                    result = timeSpan.ToString(StringFormat);
                }
                catch (Exception e)
                {
                    result = "";
                }
            }
    
            return result;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
