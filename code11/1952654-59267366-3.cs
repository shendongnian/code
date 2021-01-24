    public class MyHeaderToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find your settings for each header here.
            //and compare below with the results
            switch (value?.ToString())
            {
                case "Line #":
                    return Visibility.Visible;
                case "Data1":
                    return Visibility.Collapsed;
                default:
                    return Visibility.Visible;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
