    static void Main(string[] args)
    {
	    var now = DateTime.Now;
	    var nextRunTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
		while (true)
		{
		    var currentTime = DateTime.Now;
			if (currentTime >= nextRunTime)
			{
			    Console.WriteLine(currentTime);
				nextRunTime = nextRunTime.AddMinutes(1);
			}
		}
	}
