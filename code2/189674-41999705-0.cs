    public static DateTime Now {
        get {
            Contract.Ensures(Contract.Result<DateTime>().Kind == DateTimeKind.Local);
            DateTime utc = UtcNow; 
            Boolean isAmbiguousLocalDst = false;
            Int64 offset = TimeZoneInfo.GetDateTimeNowUtcOffsetFromUtc(utc, out isAmbiguousLocalDst).Ticks;
            long tick = utc.Ticks + offset;
            if (tick>DateTime.MaxTicks) {
                return new DateTime(DateTime.MaxTicks, DateTimeKind.Local);
            }
            if (tick<DateTime.MinTicks) {
                return new DateTime(DateTime.MinTicks, DateTimeKind.Local);
            }
            return new DateTime(tick, DateTimeKind.Local, isAmbiguousLocalDst);  
        }
    }
