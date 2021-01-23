    public class DateTimeConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.GetType() == typeof(System.DateTime))
            {
                DateTime t = (DateTime) value;
                return t.ToShortDateString();
            }
            return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return DateTime.Parse(value.ToString());
            }
            return value;
        }
    }
