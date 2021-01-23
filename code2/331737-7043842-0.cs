    public class IsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            int groupIndex = (int) value;
            if (groupIndex >= CollectionControl.Settings.SamplingFrequencyIndex)
            {
                return Visibility.Visible;
            }
    
            return Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
                throw new NotImplementedException();
        }
    }
