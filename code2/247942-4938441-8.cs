    public class CountToFontSizeConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, 
            CultureInfo culture)
        {
            const int minFontSize = 6;
            const int maxFontSize = 38;
            const int increment = 3;
            if ((minFontSize + (int)value + increment) < maxFontSize)
            {
                return (double)(minFontSize + (int)value + increment);
            }
            return (double)maxFontSize;
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
