    int GetRegularWorkingDays(DateTime startDate, DateTime endDate)
    {
    	int total = 0;
    	
    	if (startDate < endDate)
    	{
    		var days = endDate - startDate;
    		
    		for( ; startDate < endDate; startDate = startDate.AddDays(1) )
    		{
    			switch(startDate.DayOfWeek)
    			{
    				case DayOfWeek.Monday :
    				case DayOfWeek.Tuesday :
    				case DayOfWeek.Wednesday :
    				case DayOfWeek.Thursday :
    				case DayOfWeek.Friday :
    					total++;
    					break;
    				default:
    					break;
    			}
    		}
    	}
    	return total;
    }
