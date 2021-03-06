    public class FriendlyTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan ts = TimeSpan.FromSeconds((int)value);
            return String.Format("{0}:{1:D2}", ts.Minutes, ts.Seconds);                
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
