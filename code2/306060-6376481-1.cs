    // ----------------------------------------------------------------------
    public void CountWorkingDaysSample()
    {
      DayOfWeek[] workingDays = new [] { DayOfWeek.Monday, DayOfWeek.Tuesday };
      DateTime start = new DateTime( 2011, 3, 1 );
      DateTime end = new DateTime( 2011, 5, 1 );
      Console.WriteLine( "working days: {0}", CountWorkingDays( start, end, workingDays ) );
      // > working days: 19
    } // CountWorkingDaysSample
