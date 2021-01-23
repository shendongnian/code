    public class StateStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (PlaybackState)value == PlaybackState.Playing ? App.Current.Resources["RoundPlay"] : App.Current.Resources["RoundStop"];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
