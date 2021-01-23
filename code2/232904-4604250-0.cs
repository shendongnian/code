    public static int NumberOfWeeks(DateTime dateFrom, DateTime dateTo)
    {
       TimeSpan Span = dateTo.Subtract(dateFrom);
    
       if (Span.Days <= 7)
       {
          if (dateFrom.DayOfWeek > dateTo.DayOfWeek)
          {
             return 2;
          }
    
          return 1;
       }
    
       int Days = Span.Days - 7 + (int)dateFrom.DayOfWeek;
       int WeekCount = 1;
       int DayCount = 0;
    
       for (WeekCount = 1; DayCount < Days; WeekCount++)
       {
          DayCount += 7;
       }
    
       return WeekCount;
    }
