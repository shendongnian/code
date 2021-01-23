    DateTime RoundDateTimeToMonth(DateTime time)
    {
        long ticks = time.Ticks;
        return new DateTime((ticks / TimeSpan.TicksPerDay - time.Day + 1) * TimeSpan.TicksPerDay, time.Kind);
    }
