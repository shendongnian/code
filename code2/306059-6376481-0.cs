    // ----------------------------------------------------------------------
    public int CountWorkingDays( DateTime start, DateTime end, IList<DayOfWeek> workingDays )
    {
      if ( workingDays.Count == 0 )
      {
        return 0;
      }
    
      Week startWeek = new Week( start );
      Week endWeek = new Week( end );
      int dayCount = 0;
    
      // start week
      DateTime currentDay = start.Date;
      while ( currentDay < startWeek.End )
      {
        if ( workingDays.Contains( currentDay.DayOfWeek ) )
        {
          dayCount++;
        }
        currentDay = currentDay.AddDays( 1 );
      }
    
      // between weeks
      DateDiff inBetweenWeekDiff = new DateDiff( startWeek.End, endWeek.Start );
      dayCount += inBetweenWeekDiff.Weeks * workingDays.Count;
    
      // end week
      currentDay = endWeek.Start.Date;
      while ( currentDay < end )
      {
        if ( workingDays.Contains( currentDay.DayOfWeek ) )
        {
          dayCount++;
        }
        currentDay = currentDay.AddDays( 1 );
      }
    
      return dayCount;
    } // CountWorkingDays
