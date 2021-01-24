    public class EqualWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numberOfTabs = int.Parse(parameter.ToString());
            var actualWidth = (double)value;
            var equalWidth = actualWidth / numberOfTabs;
    
            // For TabItem's tiny space after the last tab.
            return equalWidth-2;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
