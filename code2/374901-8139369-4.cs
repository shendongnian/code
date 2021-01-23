    public static class ExtensionMethods
    {
	public static Tuple<int, int> GetYearsAndMonthsDifference(this DateTime dt1, DateTime dt2)
	{
		DateTime laterDate;
		DateTime earlierDate;
		
		if (dt1 > dt2)
		{
			earlierDate = dt2;
			laterDate = dt1;
		}
		else
		{
			earlierDate = dt1;
			laterDate = dt2;
		}
		int years = Math.Abs(laterDate.Year - earlierDate.Year);
		int months = Math.Abs(laterDate.Month - earlierDate.Month);
		return Tuple.Create<int, int>(years, months);
	}
    }
