    public static DateTime GetNextWeekDay(DateTime date, 
                                          IEnumerable<Holiday> holidays, 
                                          IEnumerable<DayOfWeek> weekendDays) {
    
      // public method arguments validation
      if (null == holidays)
        throw new ArgumentNullException(nameof(holidays));
      else if (null == weekendDays)
        throw new ArgumentNullException(nameof(weekendDays));
    
      HashSet<DayOfWeek> wends = new HashSet<DayOfWeek>(weekendDays);
    
      // Current Year and Next years - .AddYear(1)
      HashSet<DateTime> hds = new HashSet<DateTime>(holidays
        .Select(item => item.Date)
        .Concate(holidays.Select(item => item.Date.AddYear(1))));  
    
      for (var day = date.Date.AddDays(1); ; day = day.AddDays(1)) 
        if (!wends.Contains(day.DayOfWeek) && ! hds.Contains(day))
          return day;
    }
