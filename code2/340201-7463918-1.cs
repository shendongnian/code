    [ValueConversion(typeof(bool), typeof(Visibility))]
    internal class CheckVisibleA : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? val = value as bool?;
            string param = parameter as string;
            if (value != null)
            {
                if (val == true)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
