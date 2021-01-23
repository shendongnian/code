    // ----------------------------------------------------------------------
    public void FindRemainigYearFridaysSample()
    {
      // filter: only Fridays
      CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
      filter.WeekDays.Add( DayOfWeek.Friday );
    
      // the collecting period
      CalendarTimeRange collectPeriod = new CalendarTimeRange( DateTime.Now, new Year().End.Date );
    
      // collect all Fridays
      CalendarPeriodCollector collector = new CalendarPeriodCollector( filter, collectPeriod );
      collector.CollectDays();
    
      // show the results
      foreach ( ITimePeriod period in collector.Periods )
      {
        Console.WriteLine( "Friday: " + period );
      }
    } // FindRemainigYearFridaysSample
