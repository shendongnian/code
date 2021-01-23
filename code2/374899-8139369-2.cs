    public static class ExtensionMethods
    {
    	public static Tuple<int, int> GetYearsAndMonthsDifference(this DateTime dt1, DateTime dt2)
    	{
    		int years = Math.Abs(dt1.Year - dt2.Year);
    		int months = Math.Abs(dt1.Month - dt2.Month);
    		
    		return Tuple.Create<int, int>(years, months);
    	}
    }
