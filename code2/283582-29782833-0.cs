    public sealed class CurrentCultureDoubleConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return ((double)value).ToString((string)parameter ?? "0.######", CultureInfo.CurrentCulture);
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		double result;
    		if (Double.TryParse(value as string, NumberStyles.Number, CultureInfo.CurrentCulture, out result))
    		{
    			return result;
    		}
    
			throw new FormatException("Unable to convert value:" + value);
			// return value;
    	}
    }
