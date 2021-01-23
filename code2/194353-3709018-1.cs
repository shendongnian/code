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
    				case DayOfWeek.Saturday :
    				case DayOfWeek.Sunday :  					
    					break;
    				default:
                        total++;
    					break;
    			}
    		}
    	}
    	return total;
    }
