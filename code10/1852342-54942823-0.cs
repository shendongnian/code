    public class TimeToStringConverter : IValueConverter
    {
        public string Format { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Format = "HH:mm:ss";
            DateTime DateTimeValue = (DateTime)value;
            return DateTimeValue.ToString(Format);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();
            DateTime DateTimeValue;
            string format = "HH:mm:ss";
            if (value.ToString().Length == 4) format = "HH:mm";
            var res1 = DateTime.TryParseExact(strValue, format, null, DateTimeStyles.None, out DateTimeValue);
            if (res1) return DateTimeValue;
            return value;
        }
    }
