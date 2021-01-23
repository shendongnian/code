    /// <summary>
    /// Round the datetime
    /// </summary>
    /// <example>Round(dt, TimeSpan.FromMinutes(5)); => round the time to the nearest 5 minutes.</example>
    /// <param name = "dateTime"></param>
    /// <param name = "roundBy">The time use to round the time to</param>
    /// <returns></returns>        
    public static DateTime Round(DateTime dateTime, TimeSpan roundBy)
    {            
        long remainderTicks = dateTime.Ticks % roundBy.Ticks;
        if (remainderTicks < roundBy.Ticks / 2)
        {
            // round down
            return dateTime.AddTicks(-remainderTicks);
        }
        // round up
        return dateTime.AddTicks(roundBy.Ticks - remainderTicks);
    }
