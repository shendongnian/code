    var workDays = new DayOfWeek[]{ DayOfWeek.Monday, DayOfWeek.Tuesday};
    var days = TotalWorkDays(new DateTime(2005,1,12), new DateTime(2005,3,15), workDays);
    
    protected int TotalWorkDays(DateTime start, DateTime end, DayOfWeek[] workDays)
    {
    	var weeks = (int)Math.Floor((end - start).TotalDays / 7); 
    	var days = weeks * workDays.Length;
    	
    	//Calc rest
    	var d = start.AddDays(weeks * 7);
    	while (d <= end)
    	{
    		if(workDays.Contains(d.DayOfWeek)) 
    		    days++;
    		d = d.AddDays(1);
    		
    	}	
    	return days;
    }
