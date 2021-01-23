    DateTime testDate = new DateTime(2017, 03, 26, 00, 00, 00, DateTimeKind.Local);
    DateTime endDate = testDate.AddDays(1);
    
    //these dates also contain time!
    var start = TimeZone.CurrentTimeZone.GetDaylightChanges(testDate.Year).Start; 
    var end = TimeZone.CurrentTimeZone.GetDaylightChanges(testDate.Year).End;
    
    var hoursInDay = new List<DateTime>();
    
    while (testDate.Date != endDate.Date)
    {
    	if (start == testDate)
    	{
    		//this day have 23 hours, and should skip this hour.
    		testDate = testDate.AddHours(1);
    		continue; 
    	}
    	
    	hoursInDay.Add(testDate);
    
    	if (end == testDate)
    	{
    		hoursInDay.Add(testDate); //this day has 25 hours. add this extra hour
    	}
    		
    	testDate = testDate.AddHours(1);
    }
