    // Get weekend days of visible moth
    public List<DateTime> getWeekEndDays(DateTime dt)
    {
        List<DateTime> result = new List<DateTime>();
    
        int month = dt.Month;
        dt = dt.AddDays(-dt.Day + 1);//Sets dt to first day of month
    
        //Sets dt to the first week-end day of the month;
        if (dt.DayOfWeek != DayOfWeek.Sunday)
            while (dt.DayOfWeek != DayOfWeek.Saturday)
                dt = dt.AddDays(1);
    
        //Adds the week-end day and stops when next month is reached.
        while (dt.Month == month)
        {
            result.Add(dt);
            dt = dt.AddDays(dt.DayOfWeek == DayOfWeek.Saturday ? 1 : 6);
        }
        return result;
    }
