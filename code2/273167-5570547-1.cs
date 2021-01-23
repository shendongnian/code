    // ----------------------------------------------------------------------
    public void CombinedPeriodsSample()
    {
      TimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new MyTimeRange( 1, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 2, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 3, new DateTime( 2000, 1, 1 ), new DateTime( 2009, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 3, new DateTime( 2010, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 4, new DateTime( 2000, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 5, new DateTime( 2000, 1, 1 ), new DateTime( 2014, 12, 31 ) ) );
      periods.Add( new MyTimeRange( 5, new DateTime( 2015, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
    
      // 1;2;3(First period);4;5(First period)
      ITimePeriodCollection list1 =
        periods.IntersectionPeriods( new TimeRange( new DateTime( 2000, 1, 1 ), new DateTime( 2009, 12, 31 ) ) );
    
      // 1;2;3(Second period);4;5(First period)
      ITimePeriodCollection list2 =
        periods.IntersectionPeriods( new TimeRange( new DateTime( 2010, 1, 1 ), new DateTime( 2014, 12, 31 ) ) );
    
      // 1;2;3(Second period);4;5(Second period)
      ITimePeriodCollection list3 =
        periods.IntersectionPeriods( new TimeRange( new DateTime( 2015, 1, 1 ), new DateTime( 2019, 12, 31 ) ) );
    } // CombinedPeriodsSample
