    public class DictConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string,string> data = (Dictionary<string,string>)value;
            String parameter = (String)parameter;
            return data[parameter];
        }
    }
    
