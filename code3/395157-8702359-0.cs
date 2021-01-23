    public static int GetTimestamp()
    {
        // 10m ticks in a second, so 50m in 5 seconds
        const int ticksIn5Seconds = 50000000;
        return (int)((DateTime.Now.Ticks / ticksIn5Seconds) % 1000000);
    }
