    public class StringToDateTimeConverter : IValueConverter
    {
        private const string DateFormat = "dd/MM/yyyy HH:mm:ss";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? dt = (DateTime?)value;
            return dt.HasValue ? dt.Value.ToString(DateFormat, CultureInfo.InvariantCulture) : string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value.ToString();
            if (string.IsNullOrEmpty(s))
                return default(DateTime?);
            DateTime dt;
            return DateTime.TryParseExact(s, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) ? dt : default(DateTime?);
        }
    }
