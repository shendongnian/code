    const long LNG_OneMinuteInTicks = 600000000;
    /// <summary>
    /// Round the datetime to the nearest minute
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "numberMinutes">The number minute use to round the time to</param>
    /// <returns></returns>        
    public static DateTime Round(DateTime dateTime, int numberMinutes = 1)
    {
        long roundedMinutesInTicks = LNG_OneMinuteInTicks * numberMinutes;
        long remainderTicks = dateTime.Ticks % roundedMinutesInTicks;
        if (remainderTicks < roundedMinutesInTicks / 2)
        {
            // round down
            return dateTime.AddTicks(-remainderTicks);
        }
        // round up
        return dateTime.AddTicks(roundedMinutesInTicks - remainderTicks);
    }
