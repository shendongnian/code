    // (untested)
    // initialization:
    int iTickBase = Environment.TickCount;  // ms since boot, 10-16ms res. Wraps around. Int32 diff is the time diff, -24.9 to +24.9 days.
    uint uiTickElapsedMax = 0;
    int iTickWrap = 0;
    public static long GetIdleTime()
    {
        int iTickElapsed = Environment.TickCount - iTickBase;  // get the raw elapsed time
        unchecked {uint uiTickElapsed = (uint)iTickElapsed;}  // get the positive elapsed time
       if (uiTickElapsed >= uiTickElapsedMax)  // IF it is >= the maximum so far,
        {
            uiTickElapsedMax = uiTickElapsed;  // replace the maximum.
        }
        else  // (IF it is smaller than the maximum,)
        {
            uiTickElapsedMax = 0;  // reset the maximum.
            iTickWrap++;  // increment the wrap counter.
        }
        return (iTickWrap * (2^32) + (long)uiTickElapsedMax);
    }
