    // ----------------------------------------------------------------------
    public void DateDiffSample()
    {
      DateTime date1 = new DateTime( 2009, 11, 8, 7, 13, 59 );
      DateTime date2 = new DateTime( 2011, 3, 20, 19, 55, 28 );
      DateDiff dateDiff = new DateDiff( date1, date2 );
    
      // differences
      Console.WriteLine( "DateDiff.Months: {0}", dateDiff.Months );
      // > DateDiff.Months: 16
    
      // elapsed
      Console.WriteLine( "DateDiff.ElapsedMonths: {0}", dateDiff.ElapsedMonths );
      // > DateDiff.ElapsedMonths: 4
    
      // description
      Console.WriteLine( "DateDiff.GetDescription(6): {0}", dateDiff.GetDescription( 6 ) );
      // > DateDiff.GetDescription(6): 1 Year 4 Months 12 Days 12 Hours 41 Mins 29 Secs
    } // DateDiffSample
