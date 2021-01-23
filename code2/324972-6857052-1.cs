    public DateTime AddDaysExcluding(DateTime startDate, int days, params DateTime[] excludedDays)
    {
        while(days != 0)
        {
            if (excludedDays.Contains(startDate))
                startDate = startDate.AddDays(1);
            startDate = startDate.AddDays(1);
            days--;
        }
        
        if (excludedDays.Contains(startDate))
            startDate = startDate.AddDays(1);
    }
