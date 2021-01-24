    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		foreach(var item in GetNextWednesdays(10, DateTime.Today))
    			Console.WriteLine(item);
    	}
    	
    	public static DateTime[] GetNextWednesdays(int count, DateTime startDate)
    	{
    		var wednesday = startDate.AddDays(-(int)(DateTime.Today.DayOfWeek - DayOfWeek.Wednesday));
    		var result = new List<DateTime>();
    		result.Add(wednesday);
    		
    		for(int i = 1; i < count; i++)
    		{
    			wednesday = wednesday.AddDays(7);
    			result.Add(wednesday);
    		}
    			
    		
    		return result.ToArray();
    	}
    }
