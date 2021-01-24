    public class BoolToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return Brushes.Green; // to replace with onColor
                else
                    return Brushes.Red;  // to replace with offColor
            }
            return Brushes.LightGray;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Brush)
            {
                if ((Brush)value == Brushes.Green) // to compare with onColor
                {
                    return true;
                }
            }
            return false;
        }
    }
