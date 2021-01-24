    public class TextToColorConverter: IValueConverter
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    return value switch
		    {
			    "value1" => Color.Black,
			    "value2" => Color.Red,
			    _ => Color.Blue
		    };
	    }
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    // 
    	}
    }
