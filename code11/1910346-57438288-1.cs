    List<Holiday> holidays = new List<Holiday>
    {
    	new Holiday
    	{
    		year = 1999,
    		holidayName = "Easter"
    	},
    	new Holiday
    	{
    		year = 1999,
    		holidayName = "Christmas"
    	},
    	new Holiday
    	{
    		year = 2000,
    		holidayName = "Christmas"
    	}
    };
    
    Dictionary<int, List<Holiday>> holidaysByYear = holidays
        .GroupBy(h => h.year)
        .ToDictionary(h => h.Key, h => h.ToList());
    
    foreach (KeyValuePair<int, List<Holiday>> holidaysInYear in holidaysByYear)
    {
    	Console.WriteLine($"Holidays in {holidaysInYear.Key}");
    	foreach (Holiday holiday in holidaysInYear.Value)
    	{
    		Console.WriteLine(holiday.holidayName);
    	}
    }
