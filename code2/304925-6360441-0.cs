    public class CustomDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              CultureInfo culture)
        {
            if (value == null) { return ""; }
            DateTime dt;
            if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, 
                                  DateTimeStyles.None, out dt))
            {
                return dt.ToShortDateString();
            }
            return "";
        }
        public object ConvertBack(object value, Type targettype, object parameter, 
                                  CultureInfo culture)
        {
            if (value == null || value.ToString().Trim().Length==0) { return null; }
            string frmt = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            DateTime dt;
            if (DateTime.TryParseExact(value.ToString(), frmt, 
                                       CultureInfo.CurrentCulture, 
                                       DateTimeStyles.None, out dt))
            {
                return dt;
            }
            return DependencyProperty.UnsetValue;
        }
    }
