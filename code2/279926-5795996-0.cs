    public double SecondsToNextHour()
    {
      return SecondsToNextHour( DateTime.Now );
    }
    
    public double SecondsToNextHour( DateTime moment )
    {
      DateTime currentHour = new DateTime( moment.Year, moment.Month, moment.Day, moment.Hour, 0, 0 );
      DateTime nextHour = currentHour.AddHours( 1 );
      TimeSpan duration = nextHour - moment;
      return duration.TotalSeconds;
    }
