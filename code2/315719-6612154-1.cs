    public class CheckedConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string typeService = value as string;
                if (typeService == "Yes it is")
                {
                    return true;
                }
                if (typeService == "Nope")
                {
                    return false;
                }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool typeService = (bool)value;
                if (typeService)
                {
                    return "Yes it is";
                }
                else
                {
                    return "Nope";
                }
        }
    }
