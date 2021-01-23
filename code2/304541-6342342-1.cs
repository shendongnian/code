    // ----------------------------------------------------------------------
    public void WeekRepeatSample()
    {
      DateTime start = new DateTime( 2011, 06, 1 );
      DayOfWeek[] weekDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Thursday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 08 ), 2, weekDays ) ); // false
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 11 ), 2, weekDays ) ); // false
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 15 ), 2, weekDays ) ); // true
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 18 ), 2, weekDays ) ); // false
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 22 ), 2, weekDays ) ); // false
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 25 ), 2, weekDays ) ); // false
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 06, 29 ), 2, weekDays ) ); // true
      Console.WriteLine( "IsWeekRecuringDay: {0}", IsWeekRecuringDay( start, new DateTime( 2011, 07, 02 ), 2, weekDays ) ); // false
    } // WeekRepeatSample
