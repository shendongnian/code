    // ----------------------------------------------------------------------
    public void TimeLinePeriodsSample()
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
    
      // time line with all period start and end moments
      ITimeLineMomentCollection moments = new TimeLineMomentCollection();
      moments.AddAll( periods );
      DateTime start = periods.Start;
      foreach ( ITimeLineMoment moment in moments )
      {
        if ( moment.EndCount <= 0 ) // search the next period end
        {
          continue;
        }
        DateTime end = moment.Moment;
        TimeRange timeRange = new TimeRange( start, end );
        Console.WriteLine( "Period: {0}", timeRange );
        ITimePeriodCollection intersections = periods.IntersectionPeriods( timeRange );
        foreach ( ITimePeriod intersection in intersections )
        {
          Console.WriteLine( "  Intersection: {0}", intersection );
        }
        start = moment.Moment;
      }
    } // TimeLinePeriodsSample
