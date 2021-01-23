    // ----------------------------------------------------------------------
    public Dictionary<DateTime,int> CountMonthDays( DateTime start, DateTime end )
    {
      Dictionary<DateTime,int> monthDays = new Dictionary<DateTime, int>();
    
      Month startMonth = new Month( start );
      Month endMonth = new Month( end );
    
      if ( startMonth.Equals( endMonth ) )
      {
        monthDays.Add( startMonth.Start, end.Subtract( start ).Days );
        return monthDays;
      }
    
      Month month = startMonth;
      while ( month.Start < endMonth.End )
      {
        if ( month.Equals( startMonth ) )
        {
          monthDays.Add( month.Start, month.DaysInMonth - start.Day + 1 );
        }
        else if ( month.Equals( endMonth ) )
        {
          monthDays.Add( month.Start, end.Day );
        }
        else
        {
          monthDays.Add( month.Start, month.DaysInMonth );
        }
        month = month.GetNextMonth();
      }
    
      return monthDays;
    } // CountMonthDays
