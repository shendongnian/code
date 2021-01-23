    // ----------------------------------------------------------------------
    public void CombinedPeriodsSample()
    {
      TimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new IdTimeRange( 1, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 2, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 3, new DateTime( 2000, 1, 1 ), new DateTime( 2009, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 3, new DateTime( 2010, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 4, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 5, new DateTime( 2000, 1, 1 ), new DateTime( 2014, 12, 31 ) ) );
      periods.Add( new IdTimeRange( 5, new DateTime( 2015, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      foreach ( ITimePeriod period in periods )
      {
        Console.WriteLine( "Period: " + period );
      }
    
      // // 1;2;3(First period);4;5(First period)
      TimeRange test1 = new TimeRange( new DateTime( 2000, 1, 1 ), new DateTime( 2009, 12, 31 ) );
      ITimePeriodCollection intersections1 = periods.IntersectionPeriods( test1 );
      foreach ( ITimePeriod intersection1 in intersections1 )
      {
        Console.WriteLine( "Intersection of {0}: {1}", test1, intersection1 );
      }
    
      // // 1;2;3(Second period);4;5(First period)
      TimeRange test2 = new TimeRange( new DateTime( 2010, 1, 1 ), new DateTime( 2014, 12, 31 ) );
      ITimePeriodCollection intersections2 = periods.IntersectionPeriods( test2 );
      foreach ( ITimePeriod intersection2 in intersections2 )
      {
        Console.WriteLine( "Intersection of {0}: {1}", test2, intersection2 );
      }
    
      // // 1;2;3(Second period);4;5(Second period)
      TimeRange test3 = new TimeRange( new DateTime( 2015, 1, 1 ), new DateTime( 2019, 12, 31 ) );
      ITimePeriodCollection intersections3 = periods.IntersectionPeriods( test3 );
      foreach ( ITimePeriod intersection3 in intersections3 )
      {
        Console.WriteLine( "Intersection of {0}: {1}", test3, intersection3 );
      }
    
    } // CombinedPeriodsSample
