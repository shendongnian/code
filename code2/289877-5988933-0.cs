    // ----------------------------------------------------------------------
    public void WeekDaysSample()
    {
      Week week = new Week( new DateTime( 2011, 05, 13 ) );
      foreach ( Day day in week.GetDays() )
      {
        Console.WriteLine( "Day: {0}, DayOfWeek: {1}, Int: {2}", day, day.DayOfWeek, (int)day.DayOfWeek );
        // > Day: Montag; 09.05.2011 | 0.23:59, DayOfWeek: Monday, Int: 1
        // > Day: Dienstag; 10.05.2011 | 0.23:59, DayOfWeek: Tuesday, Int: 2
        // > Day: Mittwoch; 11.05.2011 | 0.23:59, DayOfWeek: Wednesday, Int: 3
        // > Day: Donnerstag; 12.05.2011 | 0.23:59, DayOfWeek: Thursday, Int: 4
        // > Day: Freitag; 13.05.2011 | 0.23:59, DayOfWeek: Friday, Int: 5
        // > Day: Samstag; 14.05.2011 | 0.23:59, DayOfWeek: Saturday, Int: 6
        // > Day: Sonntag; 15.05.2011 | 0.23:59, DayOfWeek: Sunday, Int: 0
      }
    } // WeekDaysSample
