    public class UnitValueConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		string text = value as string;
    		string unit = parameter as string;
    		
    		if (!string.IsNullOrWhiteSpace(text))
    		{
    			return $"{text}{unit}";
    		}
    		else
    		{
    			return text;
    		}
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
