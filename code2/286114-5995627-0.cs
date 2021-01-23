    // ----------------------------------------------------------------------
    public void QuarterOfDateSample()
    {
      DateTime moment = new DateTime( 1970, 9, 15 );
      Console.WriteLine( "Quarter  : {0}", new Quarter( moment ) );
      // > Quarter  : Q3 1970; 01.07.1970- 30.09.1970| 91.23:59
    
      Console.WriteLine( "Quarter  : {0}", new Quarter( 2006, YearQuarter.First ) );
      // > Quarter  : Q1 2006; 01.01.2006 - 31.03.2006 | 89.23:59
    } // QuarterOfDateSample
