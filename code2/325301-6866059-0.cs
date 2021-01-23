    public class MinDateConverter : IValueConverter
    {
        public MinDateConverter()
        {
        }
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            if (dt.Equals(DateTime.MinValue))
                return string.Empty;
            else
                return dt.ToShortDateString();
        }
        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
