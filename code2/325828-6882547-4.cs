    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int intValue = 0;
            string strText = value?.ToString();
            if (!string.IsNullOrEmpty(strText))
            {
                intValue = int.Parse(strText);
            }
            return intValue;
        } 
    }
