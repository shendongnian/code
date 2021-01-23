    using System;
    using System.Globalization;
    using System.Resources;
    using System.Windows.Data;
    
    public class CarColorConverter : IValueConverter
    {
        private static ResourceManager CarColors = new ResourceManager(typeof(Properties.CarColors));
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = ((Enum)value).ToString();
            var result = CarColors.GetString(key);
            if (result == null) {
                result = key;
            }
    
            return result;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
