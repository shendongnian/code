    // ----------------------------------------------------------------------
    public ITimePeriodCollection GetPastQuarters( int count )
    {
      TimePeriodCollection quarters = new TimePeriodCollection();
      Quarter quarter = new Quarter();
      for ( int i = 0; i < count; i++ )
      {
        quarters.Add( quarter );
        quarter = quarter.GetPreviousQuarter();
      }
      return quarters;
    } // GetPastQuarters
