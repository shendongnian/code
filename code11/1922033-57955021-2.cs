    public static DateTime DateHourMinute(this DateTime date)
    {
        Int64 ticks = Ticks;
        return new DateTime((UInt64)(ticks - ticks % TimeSpan.TicksPerSecond) | InternalKind);
    }
