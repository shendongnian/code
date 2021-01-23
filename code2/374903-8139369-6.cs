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
		
		int months = 0;
		
		while(earlierDate.Month != laterDate.Month || earlierDate.Year != laterDate.Year)
		{
			months++;
			earlierDate = earlierDate.AddMonths(1);
		}
		
		return Tuple.Create<int, int>(months / 12, months % 12);
	}
