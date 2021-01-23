    DateTime CalcStartDate(DateTime endTime, int daysBack)
    {
    	DateTime startTime = endTime.Date;
    	while (daysBack > 0)
    	{
    		startTime = startTime.AddDays(-1);
    		if (startTime.DayOfWeek != DayOfWeek.Saturday && startTime.DayOfWeek != DayOfWeek.Sunday)
    		{
    			--daysBack;
    		}
    	}
    
    	return startTime;
    }
