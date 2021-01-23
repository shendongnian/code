    // ----------------------------------------------------------------------
    public bool IsWeekRecuringDay( DateTime start, DateTime test, int recuringInterval, params DayOfWeek[] weekDays )
    {
      if ( test < start || recuringInterval <= 0 )
      {
        return false;
      }
    
      bool isValidDayOfWeek = false;
      DayOfWeek testDayOfWeek = test.DayOfWeek;
      foreach ( DayOfWeek weekDay in weekDays )
      {
        if ( weekDay == testDayOfWeek )
        {
          isValidDayOfWeek = true;
          break;
        }
      }
      if ( !isValidDayOfWeek )
      {
        return false;
      }
    
      DateDiff dateDiff = new DateDiff( start, test );
      return ( dateDiff.Weeks % recuringInterval ) == 0;
    } // IsWeekRecuringDay
