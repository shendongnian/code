    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? result = null;
            DateTime result2;
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    if (DateTime.TryParse(value.ToString(), out result2))
                    {
                        return result2;
                    }
                }
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? result = null;
            DateTime result2;
            if (value != null)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    if (DateTime.TryParse(value.ToString(), out result2))
                    {
                        return result2;
                    }
                }
            }
            return result;
        }
    }
