    public class DisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PropertyInfo propInfo = value.GetType().GetProperty(parameter.ToString());
            var attrib = propInfo.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);
            if (attrib.Count() > 0)
            {
                return ((System.ComponentModel.DisplayNameAttribute)attrib.First()).DisplayName;
            }
            return String.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
