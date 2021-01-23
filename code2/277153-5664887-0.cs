    private DateTime GetFirstMondayOfYear(int year)
    {
        DateTime dt = new DateTime(year, 1, 1);
        
        while (dt.DayOfWeek != DayOfWeek.Monday)
        {
        	dt = dt.AddDays(1);
        }
    
        return dt;
    }
