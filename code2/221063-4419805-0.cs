    public const Int64 ticks_per_millisecond = System.TimeSpan.TicksPerMillisecond;
    public static long GetCurrentTimeInTicks()
    {
        return Microsoft.SPOT.Hardware.Utility.GetMachineTime().Ticks;
    }
