    wednesday = wednesday > startDate ? startDate : wednesday.AddDays(7); 
    // Wednesdays on or after the given date
    public static DateTime[] GetNextWednesdays(int count, DateTime startDate)
    {
    		var wednesday = startDate.AddDays(DayOfWeek.Wednesday - startDate.DayOfWeek); // Get the date of Wednesday in week
    		wednesday = wednesday > startDate ? startDate : wednesday.AddDays(7); // Wednesdays on or after the given date
    		
    		var result = new DateTime[count];
    		result[0] = wednesday;
    		
    		for(int i = 1; i < count; i++)
    		{
    			wednesday = wednesday.AddDays(7);
    			result[i] = wednesday;
    		}
    			
    		
    		return result;
    }
