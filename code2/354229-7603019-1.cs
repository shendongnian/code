    public static DateTime RoundedDate(DateTime eventTime, EventTimings strategy)
    {
       switch (strategy)
          case EventTimings.Weekly :
             return WeeklyRounding(eventTime);
       ... etc ...
