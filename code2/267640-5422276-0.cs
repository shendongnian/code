    // dt: The date to start from (usually DateTime.Now)
    // n: The nth occurance (3rd)
    // weekday: the day of the week to look for
    public DateTime GetNthWeekdayOfMonth(DateTime dt, int n, DayOfWeek weekday)
    {
 		var days = Enumerable.Range(1, DateTime.DaysInMonth(dt.Year, dt.Month)).Select(day => new DateTime(dt.Year, dt.Month, day));
    
 		var weekdays = from day in days
    						where day.DayOfWeek == weekday
    						orderby day.Day ascending
    						select day;
    
    	int index = n - 1;
    
    	if (index >= 0 && index < weekdays.Count())
    		return weekdays.ElementAt(index);
    
    	else
    		throw new InvalidOperationException("The specified day does not exist in this month!");
   }
