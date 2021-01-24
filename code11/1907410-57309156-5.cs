    public static int Compare(DateTime t1, DateTime t2) {
        Int64 ticks1 = t1.InternalTicks;
        Int64 ticks2 = t2.InternalTicks;
        if (ticks1 > ticks2) return 1;
        if (ticks1 < ticks2) return -1;
        return 0;
    }
