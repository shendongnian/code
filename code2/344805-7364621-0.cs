    DateTime start = DateTime.Now.Date;
    DatTime end = start.AddYears( 1 );
    Week week = new Week( start );
    while ( week.Start < end )
    {
      Console.WriteLine( "week " + week );
      week = week.GetNextWeek();
    }
