        public class ValConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == "")
            {
                if ((value as bool?) ?? false)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
            else if (parameter == "")
            {
                if ((value as bool?) ?? false)
                    return new SolidColorBrush(Colors.Black);
                else
                    return new SolidColorBrush(Colors.Red);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == "Visibility")
            {
                if ((System.Windows.Visibility)value == Visibility.Visible)
                    return false;
                else
                    return true;
            }
            else if (parameter == "Brush")
            {
                if (((SolidColorBrush)value).Color == Colors.Black)
                    return true;
                else
                    return false;
            }
           
        }
