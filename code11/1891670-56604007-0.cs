    public class Program
    {
	    public static void Main()
	    {
		    Console.WriteLine(DetermineMarketValue(2019));
	    }
	
	    public static double DetermineMarketValue(int Year)
        {
            double carValue = 1000;
            if (Year > 1990)
			{
				int numYears = Math.Abs(Year - 1990);
				carValue = 1000 + (numYears * 200);
			}
            return carValue;
        }
    }
