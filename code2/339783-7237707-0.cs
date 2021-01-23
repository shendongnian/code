    void Main()
    {
    	DateTime today = new DateTime(2011, 8, 29);
    	DateTime nextWeek = new DateTime(2011, 9, 4);
    	
    	foreach (DateTime dateTime in today.ListAllDates(nextWeek))
    	{
    	   Console.WriteLine(dateTime);
    	}
    	Console.ReadLine();
    }
    
    public static class DateTimeExtenions
    {
    	public static IEnumerable<DateTime> ListAllDates(this DateTime lhs, DateTime futureDate)
    	{	
    		List<DateTime> dateRange = new List<DateTime>();
    		TimeSpan difference = (futureDate - lhs);
    		for(int i = 0; i <= difference.Days; i++)
    		{
    			dateRange.Add(lhs.AddDays(i));
    		}
    		return dateRange;
    	}
    }
