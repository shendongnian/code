    // ----------------------------------------------------------------------
    public void CalendarYearTimePeriodsSample()
    {
      DateTime moment = new DateTime( 2011, 8, 15 );
      Console.WriteLine( "Calendar Periods of {0}:", moment.ToShortDateString() );
      // > Calendar Periods of 15.08.2011:
      Console.WriteLine( "Year     : {0}", new Year( moment ) );
      Console.WriteLine( "Halfyear : {0}", new Halfyear( moment ) );
      Console.WriteLine( "Quarter  : {0}", new Quarter( moment ) );
      Console.WriteLine( "Month    : {0}", new Month( moment ) );
      Console.WriteLine( "Week     : {0}", new Week( moment ) );
      Console.WriteLine( "Day      : {0}", new Day( moment ) );
      Console.WriteLine( "Hour     : {0}", new Hour( moment ) );
      // > Year     : 2011; 01.01.2011 - 31.12.2011 | 364.23:59
      // > Halfyear : HY2 2011; 01.07.2011 - 31.12.2011 | 183.23:59
      // > Quarter  : Q3 2011; 01.07.2011 - 30.09.2011 | 91.23:59
      // > Month    : August 2011; 01.08.2011 - 31.08.2011 | 30.23:59
      // > Week     : w/c 33 2011; 15.08.2011 - 21.08.2011 | 6.23:59
      // > Day      : Montag; 15.08.2011 - 15.08.2011 | 0.23:59
      // > Hour     : 15.08.2011; 00:00 - 00:59 | 0.00:59
    } // CalendarYearTimePeriodsSample
