    [ValueConversion(typeof(TimeSpan), typeof(String))]
    public class HoursMinutesTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              Globalization.CultureInfo culture)
        {
            // TODO something like:
            return ((TimeSpan)value).ToString("hh\:mm");
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  Globalization.CultureInfo culture)
        {
            // TODO something like:
            return TimeSpan.ParseExact(value, "hh:\mm", CultureInfo.CurrentCulture);
        }
    }
