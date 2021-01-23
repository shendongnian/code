    [ValueConversion(typeof(bool), typeof(string))]
    public class TrueFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolean = (bool)boolean;
            return boolean.ToString();
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
    // Convert the other way around if needed else throw NotImplementedException...
        }
    }
