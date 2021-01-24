    public static DateTime GetNextWeekDay(DateTime date, 
                                          IEnumerable<Holiday> holidays, 
                                          IEnumerable<DayOfWeek> weekendDays) {
    
      // public method arguments validation
      if (null == holidays)
        throw new ArgumentNullException(nameof(holidays));
      else if (null == weekendDays)
        throw new ArgumentNullException(nameof(weekendDays));
    
      HashSet<DayOfWeek> wends = new HashSet<DayOfWeek>(weekendDays);
    
      // Current Year and Next year - .AddYear(1)
      HashSet<DateTime> hds = new HashSet<DateTime>(holidays
        .Concate(holidays.Select(date => date.AddYear(1))));  
    
      for (date = date.Date.AddDays(1); ; date = date.AddDays(1)) 
        if (!wends.Contains(date.DayOfWeek) && ! hds.Contains(date))
          return date;
    }
