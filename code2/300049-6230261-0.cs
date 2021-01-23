    public IEnumerable<DateTime> GetHourlyBreakdown(DateTime startDate, DateTime endDate)
    {
    	var hours = new List<DateTime>();
    	hours.Add(startDate);
    	var currentDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, 0, 0).AddHours(1);
    	while(currentDate < endDate)
    	{
    		hours.Add(new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, 0, 0));
    		currentDate = currentDate.AddHours(1);
    	}
    	hours.Add(endDate);
    	return hours;
    }
