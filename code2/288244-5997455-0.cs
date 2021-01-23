    // ----------------------------------------------------------------------
    public int GetMonthOfWeek( int weekOfYear )
    {
      return new Week( weekOfYear ).FirstDayStart.Month;
    } // GetMonthOfWeek
