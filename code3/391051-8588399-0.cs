    private Date[] _publicHolidays = { new Date(2011, 12, 25) };
    
    public Date GetPreviousWorkingDay(Date date) 
    { 
        Date previousDay;
    
        switch(date.DayOfWeek) 
        { 
            case DayOfWeek.Sunday: 
                previousDay = date.AddDays(-2); 
            case DayOfWeek.Monday: 
                previousDay = date.AddDays(-3); 
            default: 
                previousDay = date.AddDays(-1); 
        } 
    
        if (_publicHolidays.Contains(previousDay))
       {
          return GetPreviousWorkingDay(previousDay);
       }
    }  
