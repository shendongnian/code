    public class TimeSpanConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		var time = (TimeSpan) value;
    		return time.TotalMinutes + ":" + time.Seconds;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotSupportedException();
    	}
    }
