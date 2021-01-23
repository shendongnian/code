    static int CountDayOfWeekInMonth(int year, int month, DayOfWeek dayOfWeek)
    {
      DateTime startDate = new DateTime(year, month, 1);
      int days = DateTime.DaysInMonth(startDate.Year, startDate.Month);
      int weekDayCount = 0;
      for (int day = 0; day < days; ++day)
      {
        weekDayCount += startDate.AddDays(day).DayOfWeek == dayOfWeek ? 1 : 0;        
      }
      return weekDayCount;
    }
