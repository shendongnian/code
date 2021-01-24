    public long ToUnixTimeSeconds() {
        // Truncate sub-second precision before offsetting by the Unix Epoch to avoid
        // the last digit being off by one for dates that result in negative Unix times.
        //
        // For example, consider the DateTimeOffset 12/31/1969 12:59:59.001 +0
        //   ticks            = 621355967990010000
        //   ticksFromEpoch   = ticks - UnixEpochTicks                   = -9990000
        //   secondsFromEpoch = ticksFromEpoch / TimeSpan.TicksPerSecond = 0
        //
        // Notice that secondsFromEpoch is rounded *up* by the truncation induced by integer division,
        // whereas we actually always want to round *down* when converting to Unix time. This happens
        // automatically for positive Unix time values. Now the example becomes:
        //   seconds          = ticks / TimeSpan.TicksPerSecond = 62135596799
        //   secondsFromEpoch = seconds - UnixEpochSeconds      = -1
        //
        // In other words, we want to consistently round toward the time 1/1/0001 00:00:00,
        // rather than toward the Unix Epoch (1/1/1970 00:00:00).
        long seconds = UtcDateTime.Ticks / TimeSpan.TicksPerSecond;
        return seconds - UnixEpochSeconds;
    }
    
    // Number of days in a non-leap year
    private const int DaysPerYear = 365;
    // Number of days in 4 years
    private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
    // Number of days in 100 years
    private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
    // Number of days in 400 years
    private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097
    // Number of days from 1/1/0001 to 12/31/1600
    private const int DaysTo1601 = DaysPer400Years * 4;          // 584388
    // Number of days from 1/1/0001 to 12/30/1899
    private const int DaysTo1899 = DaysPer400Years * 4 + DaysPer100Years * 3 - 367;
    // Number of days from 1/1/0001 to 12/31/1969
    internal const int DaysTo1970 = DaysPer400Years * 4 + DaysPer100Years * 3 + DaysPer4Years * 17 + DaysPerYear; // 719,162        
    
