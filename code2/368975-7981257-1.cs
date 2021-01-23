	public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
	{
		var date = dt;
		
		// Find the first future occurance of the day.
		while(date.DayOfWeek != weekday)
			date = date.AddDays(1);
	
		return Enumerable.Range(0, amounttoshow).Select(i => date.AddDays(i * 7));
	}
