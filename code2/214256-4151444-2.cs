    DateTime startTime = DateTime.Today.AddHours(10);
    DateTime endTime = DateTime.Today.AddHours(17).AddMinutes(30);
    int inc = 1;
    List<DateTime> timeList = new List<DateTime>();
    while (startTime < endTime)
    {
    	timeList.Add(startTime);
    	startTime = startTime.AddMinutes(inc);
    }
    timeList.Add(endTime);
