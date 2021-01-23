    public class MyConverter : IValueConverter
    {
        public object lastValue;
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
    	    if (LastValue != null && MyConvertBack(LastValue).Equals(value))
    		    return lastValue;
    		else
    		    return MyConvert(value);
    		
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            lastValue = value;
            return MyConvertBack(value);
        }
    	
    	private object MyConvertBack(Object value)
    	{
    		//Conversion Code Here
    	}
    	
    	private object MyConvert(Object value)
    	{
    		//Conversion Code Here
    	}
    }
