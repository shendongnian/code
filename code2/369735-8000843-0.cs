    public class MyCustomValueConverter: IValueConverter
    {    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter.ToString()== "URL")
            {
                // return the URL part of the string
            }
            else
            {
                // return the non-URL portion of the string
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
