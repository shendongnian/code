    public DateTime GetPreviousWorkingDay(DateTime date)
    {
    	switch(date.DayOfWeek)
    	{
    		case DayOfWeek.Sunday:
    			return date.AddDays(-2);
    		case DayOfWeek.Monday:
    			return date.AddDays(-3);
    		default:
    			return date.AddDays(-1);
    	}
    }
