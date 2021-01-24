	public static void Main()
	{
		var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
		var endTime = new DateTime(2019, 01, 01, 16, 0 , 0);
        // prints 10:00 AM
		Console.WriteLine(GetTime(0.5, startTime, endTime));
	}
	
	private static string GetTime(double percentage, DateTime startTime, DateTime endTime)
	{
        // get the difference between the dates
        // you could use TotalSeconds or a higher precision if needed
		var diff = (endTime - startTime).TotalMinutes;
        // multiply the result by the percentage
        // assuming a range of [0.0, 1.0]
		double minutes = diff * percentage;
		
        // add the minutes (or precision chosen) to the startTime
		var result = startTime.AddMinutes(minutes);
		
        // and get the result
		return result.ToShortTimeString();
	}
