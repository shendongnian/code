        [ValueConversion(typeof(Int32), typeof(Visibility))]
        public class IntVisabilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                Int32 inCount = (Int32)value;
                if (inCount > 0) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return true;
            }
        }
