    // ----------------------------------------------------------------------
    public void CalendarPeriodCollectorSample()
    {
      CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
      filter.Months.Add( YearMonth.January ); // only Januaries
      filter.WeekDays.Add( DayOfWeek.Friday ); // only Fridays
      filter.CollectingHours.Add( new HourRange( 8, 18 ) ); // working hours
    
      CalendarTimeRange testPeriod =
        new CalendarTimeRange( new DateTime( 2010, 1, 1 ), new DateTime( 2011, 12, 31 ) );
      Console.WriteLine( "Calendar period collector of period: " + testPeriod );
      // > Calendar period collector of period:
      //            01.01.2010 00:00:00 - 30.12.2011 23:59:59 | 728.23:59
    
      CalendarPeriodCollector collector =
              new CalendarPeriodCollector( filter, testPeriod );
      collector.CollectHours();
      foreach ( ITimePeriod period in collector.Periods )
      {
        Console.WriteLine( "Period: " + period );
      }
      // > Period: 01.01.2010; 08:00 - 17:59 | 0.09:59
      // > Period: 08.01.2010; 08:00 - 17:59 | 0.09:59
      // > Period: 15.01.2010; 08:00 - 17:59 | 0.09:59
      // > Period: 22.01.2010; 08:00 - 17:59 | 0.09:59
      // > Period: 29.01.2010; 08:00 - 17:59 | 0.09:59
      // > Period: 07.01.2011; 08:00 - 17:59 | 0.09:59
      // > Period: 14.01.2011; 08:00 - 17:59 | 0.09:59
      // > Period: 21.01.2011; 08:00 - 17:59 | 0.09:59
      // > Period: 28.01.2011; 08:00 - 17:59 | 0.09:59
    } // CalendarPeriodCollectorSample
