    public static DateTime GetNextSunday (DateTime date)
    {
         if (date.DayOfWeek == DayOfWeek.Sunday)
              date = date.AddDays(1);
         while (date.DayOfWeek != DayOfWeek.Sunday)
              date = date.AddDays(1);
    
         return date;
    }
