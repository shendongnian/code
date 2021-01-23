    public static class DateTimeExtensions
    {
    	public static bool IsLeapYear(this DateTime source)
    	{
    		return DateTime.IsLeapYear(source.Year);
    	}
    }
