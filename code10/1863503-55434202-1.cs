    public class TextToBackgroundConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string stringval = value.ToString();
            if(!string.IsNullOrEmpty(stringval)) return Brushes.Transparent;
            else return Brushes.Yellow;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
           return Binding.DoNothing;
        }
    }
