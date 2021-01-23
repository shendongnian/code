    // ----------------------------------------------------------------------
    public void SequentialPeriodsDemo()
    {
      // sequential
      ITimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new Days( new DateTime( 2011, 5, 4 ), 2 ) );
      periods.Add( new Days( new DateTime( 2011, 5, 6 ), 3 ) );
      Console.WriteLine( "Sequential: " + IsSequential( periods ) );
    
      periods.Add( new Days( new DateTime( 2011, 5, 10 ), 1 ) );
      Console.WriteLine( "Sequential: " + IsSequential( periods ) );
    } // SequentialPeriodsDemo
    
    // --------------------------------------------------------------------
    public bool IsSequential( ITimePeriodCollection periods, ITimePeriod limits = null )
    {
      return new TimeGapCalculator<TimeRange>( 
        new TimeCalendar() ).GetGaps( periods, limits ).Count == 0;
    } // IsSequential
