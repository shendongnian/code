    public class DateConverter : IValueConverter
    {
        private static readonly DateTime s_defaultDate = new DateTime(1900, 01, 01);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date == s_defaultDate ? string.Empty : date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
