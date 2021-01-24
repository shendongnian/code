    public class Program
    {
    	public static void Main()
    	{
    		DateTime endDate = DateTime.Parse("2019-10-01 23:59:59");
    		DateTime startDate2 = DateTime.Parse("2019-10-04 00:00:00");
    		DateTime endDate2 = DateTime.Parse("2019-10-01 00:00:00");
    		
    		Console.WriteLine(DateTime.Now.ToString());
    		Console.WriteLine(endDate.ToString());
    
    		Console.WriteLine("With today timespan:" + DaysToShowByTimeComp(DateTime.Now, endDate));		
    		Console.WriteLine("With today date comparison:" + DaysToShowByDateComp(DateTime.Now, endDate));
    		
    		Console.WriteLine("With other timespan:" + DaysToShowByTimeComp(startDate2, endDate2));		
    		Console.WriteLine("With other date comparison:" + DaysToShowByDateComp(startDate2, endDate2));
    	}
    	
    	private static int DaysToShowByTimeComp(DateTime start, DateTime end) 
    	{
        	//Find the difference in the days selected in the drop down menu so we can calculate
        	DateTime dtDateOnQuay = end;
        	DateTime dtDateLeft = start;
        	TimeSpan difference = dtDateLeft - dtDateOnQuay;
    
        	//As the days are inclusive and the above gets the days in between, add 1
        	return difference.Days + 1;
    	}
    	
    	private static int DaysToShowByDateComp(DateTime start, DateTime end) 
    	{
    		return (int)((start.Date - end.Date).TotalDays) + 1;
    	}
    }
