    public DateTime Date
    {
        get
        {
            Int64 ticks = InternalTicks;
            return new DateTime((UInt64)(ticks - ticks % TicksPerDay) | InternalKind);
        }
    } 
