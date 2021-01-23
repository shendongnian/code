    private static readonly bool IsSingleCpuMachine = (Environment.ProcessorCount == 1);
    [DllImport("kernel32", ExactSpelling = true)]
    private static extern void SwitchToThread();
    private static void StallThread()
    {
        // On a single-CPU system, spinning does no good
        if (IsSingleCpuMachine) SwitchToThread();
        // Multi-CPU system might be hyper-threaded, let other thread run
        else Thread.SpinWait(1);
    }
    while (true)
    {
        // Do something.
        StallThread();
    }
