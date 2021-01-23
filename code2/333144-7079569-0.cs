    public class UnitConverter : IMultiValueConverter
    {
        private string _units;
        public object Convert(object[ ] values, Type targetType, object parameter, CultureInfo culture)
        {
             //Initialize
             _units = values[1];
             //Convert
        }
        public object Convert(object[ ] values, Type targetType, object parameter, CultureInfo culture)
        {
             //Use _units to convert back
        }
    }
