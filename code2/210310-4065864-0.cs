    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
    for (DateTime tm = startDate; tm <= endDate; tm.AddDays(7))
    {
      int whatever = System.Globalization.Calendar.GetWeekOfYear(tm, dfi.CalendarWeekRule, 
                                              dfi.FirstDayOfWeek);
    }
