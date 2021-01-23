    public int MonthOfWeek( int week, int year, CalendarWeekRule, weekrule, DayOfWeek firstDayOfWeek)
    {
      GregorianCalendar gc = new GregorianCalendar();
      for( DateTime dt = new DateTime(year, 1, 1); dt.Year == year; dt = dt.AddDays(1))
      {
        if( gc.GetWeekOfYear( dt, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) == week ){
          return dt.Month;
        }
      }
      return -1;
    }  
