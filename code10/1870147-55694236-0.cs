    public class Example
    {
       public static void Main()
       {
           var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
    	   var (cityName, _, year1, pop3, _, pop4) = QueryCityDataForYears("New York City", 1980, 2010);
    
           Console.WriteLine($"Population change, in 1960 to 2010: {pop2 - pop1:N0}");
           Console.WriteLine($"Population change, in {cityName}  from {year1} to 2010: {pop4 - pop3:N0}");
       }
       
    	private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
    	{
    		int population1 = 0, population2 = 0;
    		double area = 0;
    		
    		if (name == "New York City") 
    		{
    			area = 468.48; 
    			if (year1 == 1960) 
    			{
    				population1 = 7781984;
    			}
    			if (year1 == 1980) 
    			{
    				population1 = 7981984;
    			}
    			if (year2 == 2010) 
    			{
    				population2 = 8175133;
    			}
    			
    			return (name, area, year1, population1, year2, population2);
    		}
    		
    		return ("", 0, 0, 0, 0, 0);
    	}
    }
    
    //Output
    //Population change, in 1960 to 2010: 393,149
    //Population change, in New York City  from 1980 to 2010: 193,149
