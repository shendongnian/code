    public void TimePeriodIntersectorSample()
    {
        TimePeriodCollection periods = new TimePeriodCollection();
    
        periods.Add( new TimeRange( new DateTime( 2011, 3, 01 ), new DateTime( 2011, 3, 10 ) ) );
        periods.Add( new TimeRange( new DateTime( 2011, 3, 05 ), new DateTime( 2011, 3, 15 ) ) );
        periods.Add( new TimeRange( new DateTime( 2011, 3, 12 ), new DateTime( 2011, 3, 18 ) ) );
    
        periods.Add( new TimeRange( new DateTime( 2011, 3, 20 ), new DateTime( 2011, 3, 24 ) ) );
        periods.Add( new TimeRange( new DateTime( 2011, 3, 22 ), new DateTime( 2011, 3, 28 ) ) );
        periods.Add( new TimeRange( new DateTime( 2011, 3, 24 ), new DateTime( 2011, 3, 26 ) ) );
    
        TimePeriodIntersector<TimeRange> periodIntersector = 
    					new TimePeriodIntersector<TimeRange>();
        ITimePeriodCollection intersectedPeriods = periodIntersector.IntersectPeriods( periods );
    
        foreach ( ITimePeriod intersectedPeriod in intersectedPeriods )
        {
            Console.WriteLine( "Intersected Period: " + intersectedPeriod );
        }
        // > Intersected Period: 05.03.2011 - 10.03.2011 | 5.00:00
        // > Intersected Period: 12.03.2011 - 15.03.2011 | 3.00:00
        // > Intersected Period: 22.03.2011 - 26.03.2011 | 4.00:00
    } // TimePeriodIntersectorSample
