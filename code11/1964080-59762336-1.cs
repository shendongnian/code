    using System;
    using System.Collections.Generic;
    // https://stackoverflow.com/questions/59762265/datetime-objects-with-c-sharp					
    public class Program
    {
    	public static void Main()
    	{
    		foreach(var item in GetNextWednesdays(10, DateTime.Today.AddDays(2)))
    			Console.WriteLine(item);
    	}
    	
    	public static DateTime[] GetNextWednesdays(int count, DateTime startDate)
    	{
    		var wednesday = startDate.AddDays(-(startDate.DayOfWeek - DayOfWeek.Wednesday)); // Get the date of Wednesday in week
    		var result = new DateTime[10];
    		result[0] = wednesday;
    		
    		for(int i = 1; i < count; i++)
    		{
    			wednesday = wednesday.AddDays(7);
    			result[i] = wednesday;
    		}
    			
    		
    		return result;
    	}
    }
    		
    		return result.ToArray();
    	}
    }
