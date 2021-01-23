    /// <summary>
    /// PERF_100NSEC_TIMER_INV algorithm.
    /// </summary>
    /// <param name="n2"></param>
    /// <param name="d2"></param>
    /// <param name="n1"></param>
    /// <param name="d1"></param>
    /// <returns></returns>
    public static int CalculatePerf100NsecTimerInv(long n2, UInt64 d2,
                                                   long n1, UInt64 d1)
    {
        int usage = 0;
        try
        {
            double dataDiff = (n2 - n1);
            double timeDiff = (d2 - d1);
            double dUsage = (1 - (dataDiff / timeDiff)) * 100;
            // Evaluate
            usage = (dUsage >= 0.5) ? Convert.ToInt32(Math.Ceiling(dUsage)) : 0;
        }
        catch { }
        // Return
        return usage;
    }
