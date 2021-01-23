    public class SpaceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return System.Convert.ToString(value); 
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string text = System.Convert.ToString(value);
    
                //the meat and potatoes is this line
                text = text.Replace(" ", "_");    
    
                return text;
            }
        }
