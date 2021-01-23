    // ----------------------------------------------------------------------
    public void CountDaysByMonthSample()
    {
      DateTime start = new DateTime( 2011, 3, 30 );
      DateTime end = new DateTime( 2011, 4, 5 );
    
      Dictionary<DateTime, int> monthDays = CountMonthDays( start, end );
      foreach ( KeyValuePair<DateTime, int> monthDay in monthDays )
      {
        Console.WriteLine( "month {0:d}, days {1}", monthDay.Key, monthDay.Value );
      }
      // > month 01.03.2011, days 2
      // > month 01.04.2011, days 5
    } // CountDaysByMonthSample
