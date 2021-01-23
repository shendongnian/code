	public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, 
		DayOfWeek weekday, int amounttoshow = 4)
	{
		var day = dt.AddDays(weekday > dt.DayOfWeek 
		    ? weekday - dt.DayOfWeek
		    : 7 - weekday - dt.DayOfWeek);
		var days = new List<DateTime>();
		for(var until = day.AddDays(7 * amounttoshow); 
		    day < until; 
		    day = day.AddDays(7))
			days.Add(day);
		return days.ToArray();
	}
