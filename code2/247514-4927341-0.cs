    TimeZoneInfo getTimeZone(string gmtstring)
    {
      foreach(TimeZoneInfo ti in TimeZoneInfo.GetSystemTimeZones())
      {
        TimeSpan tsp = ti.BaseUtcOffset;
        if(tsp.ToString((tsp.TotalMinutes < 0 ? "-" : "+")+"hh:mm") == gmtstring.Substring(3))
          return ti;
      }
      return null;
    }
