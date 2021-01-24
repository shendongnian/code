    public class GraphValueConverter:IValueConverter  
        {  
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
            {  
                var graph = value as Graph;
                // check for null
                return graph.Step;  
            }  
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)  
            {  
                throw new NotImplementedException();  
            }  
        }  
