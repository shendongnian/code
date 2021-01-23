    public static DateTime RoundedDate(DateTime eventTime, EventTimings strategy)
    {
       switch (strategy)
          case EventTimings.Every12Hours:
             return WeeklyRounding(eventTime);
       ... etc ...
