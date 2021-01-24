    int Year = 2019;
    int Month = 2;
    
    int TotalDaysInMonth = DateTime.DaysInMonth(Year, Month);
    for (int i = 1; i <= TotalDaysInMonth; i++)
    {
    	DateTime dt = new DateTime(Year, Month, i);
    	// Insert it into your Model...
    }
