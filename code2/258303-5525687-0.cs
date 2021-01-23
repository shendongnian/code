    // ----------------------------------------------------------------------
    public void TimePeriodCombinerSample()
    {
      TimePeriodCollection periods = new TimePeriodCollection();
    
      periods.Add( new TimeRange( new DateTime( 2011, 3, 01 ), new DateTime( 2011, 3, 10 ) ) );
      periods.Add( new TimeRange( new DateTime( 2011, 3, 04 ), new DateTime( 2011, 3, 08 ) ) );
    
      periods.Add( new TimeRange( new DateTime( 2011, 3, 15 ), new DateTime( 2011, 3, 18 ) ) );
      periods.Add( new TimeRange( new DateTime( 2011, 3, 18 ), new DateTime( 2011, 3, 22 ) ) );
      periods.Add( new TimeRange( new DateTime( 2011, 3, 20 ), new DateTime( 2011, 3, 24 ) ) );
    
      periods.Add( new TimeRange( new DateTime( 2011, 3, 26 ), new DateTime( 2011, 3, 30 ) ) );
    
      TimePeriodCombiner<TimeRange> periodCombiner = new TimePeriodCombiner<TimeRange>();
      ITimePeriodCollection combinedPeriods = periodCombiner.CombinePeriods( periods );
    
      foreach ( ITimePeriod combinedPeriod in combinedPeriods )
      {
        Console.WriteLine( "Combined Period: " + combinedPeriod );
      }
      // > Combined Period: 01.03.2011 - 10.03.2011 | 9.00:00
      // > Combined Period: 15.03.2011 - 24.03.2011 | 9.00:00
      // > Combined Period: 26.03.2011 - 30.03.2011 | 4.00:00
    } // TimePeriodCombinerSample
