    public class BoolToColorConverter: IValueConverter
    {
    	public Color TrueColor { get; set; }
    
    	public Color FalseColor { get; set; }
    
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (value != null && value is bool boolValue)
    			return boolValue ? TrueColor : FalseColor;
    		return FalseColor;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
