    public class DoubleToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double input = 0;
            if (value is double)
            {
                input = (double)value;
            }
            else if (value is int)
            {
                input = (int)value;
            }
            else if (value is string) // Useful if input of converter is written in XAML
            {
                if (!double.TryParse((string)value, out input))
                    return Binding.DoNothing;
            }
            else
            {
                return Binding.DoNothing;
            }
            return (input > 0 ? Visibility.Visible : Visibility.Collapsed);
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
