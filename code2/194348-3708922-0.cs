    int GetRegularWorkingDays(DateTime startDate, DateTime endDate)
    {
       int days = 0;
       while (startDate <= endDate)
       {
           if (startDate.DayOfWeek != DayOfWeek.SaturDay 
                 && startDate.DayOfWeek != DayOfWeek.Sunday)
           {
               days += 1;
           }
           startDate = startDate.AddDays(1);
       }
       return days;
    }
