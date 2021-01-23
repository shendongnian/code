    public static TimeSpan AddMinutes(this TimeSpan span, double mins)
    {
      return span.Add(TimeSpan.FromMinutes(mins));
    }
    
    public static string ToHourAndMins(this TimeSpan span)
    {
      return string.Format("{0}:{1:00}", Math.Truncate(span.TotalHours), span.Minutes);
    }
