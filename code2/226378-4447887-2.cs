    public void MeasureLockUnlockOverhead()
    {
        const int TestIterations = 5;
        Action<string, Func<double>> test = (name, action) =>
        {
            for (int i = 0; i < TestIterations; i++)
            {
                Console.WriteLine("{0}:{1:F2}ms", name, action());
            }
        };
        Action<int> lockUnlock = interval =>
        {
            WriteableBitmap bitmap =
               new WriteableBitmap(100, 100, 96d, 96d, PixelFormats.Bgr32, null);
            int counter = 0;
            Action t1 = () =>
            {
                if (++counter % interval == 0)
                {
                    bitmap.Lock();
                    bitmap.Unlock();
                }
            };
            string title = string.Format("lock/unlock - Interval:{0} -", interval);
            test(title, () => TimeTest(t1));
        };
        lockUnlock(1);
        lockUnlock(10);
    }
    [SuppressMessage("Microsoft.Reliability",
        "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect")]
    private static double TimeTest(Action action)
    {
        const int Iterations = 100 * 1000;
        Action gc = () =>
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
        };
        Action empty = () => { };
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        for (int j = 0; j < Iterations; j++)
        {
            empty();
        }
        double loopElapsed = stopwatch1.Elapsed.TotalMilliseconds;
        gc();
        action(); //JIT
        action(); //Optimize
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        for (int j = 0; j < Iterations; j++)
        {
            action();
        }
        gc();
        double testElapsed = stopwatch2.Elapsed.TotalMilliseconds;
        return (testElapsed - loopElapsed);
    }
