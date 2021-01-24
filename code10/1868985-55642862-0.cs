    static DateTime? NthWeekDayOfMonth( int n, DayOfWeek dow, int year , int month)
    {
      DateTime startOfMonth      = new DateTime( year, month, 1 ) ;
      int      offset            = ( 7 + dow - startOfMonth.DayOfWeek ) % 7 ;
      DateTime nthWeekDayOfMonth = startOfMonth
                                 .AddDays( offset    )
                                 .AddDays( 7 * (n-1) )
                                 ;
      bool isSameMonth           =  startOfMonth.Year  == nthWeekDayOfMonth.Year
                                 && startOfMonth.Month == nthWeekDayOfMonth.Month
                                 ;
      return isSameMonth
        ? nthWeekDayOfMonth
        : (DateTime?) null
        ;
    }
