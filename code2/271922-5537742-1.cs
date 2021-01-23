    // ----------------------------------------------------------------------
    public void GetDaysOfPastQuarter( DateTime moment,
           out DateTime firstDay, out DateTime lastDay )
    {
      TimeCalendar calendar = new TimeCalendar(
        new TimeCalendarConfig { YearBaseMonth = YearMonth.October } );
      Quarter quarter = new Quarter( moment, calendar );
      Quarter pastQuarter = quarter.GetPreviousQuarter();
    
      firstDay = pastQuarter.FirstDayStart;
      lastDay = pastQuarter.LastDayStart;
    } // GetDaysOfPastQuarter
