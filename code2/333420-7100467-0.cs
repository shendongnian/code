    public static class Performance
    {
        public static void Test(string name, decimal times, bool precompile, Action fn)
        {
            if (precompile)
            {
                fn();
            }
            GC.Collect();
            Thread.Sleep(2000);
            var sw = new Stopwatch();
            sw.Start();
            for (decimal i = 0; i < times; ++i)
            {
                fn();
            }
            sw.Stop();
            Console.WriteLine("[{0,15}: {1,-15}]", name, new DateTime(sw.Elapsed.Ticks).ToString("HH:mm:ss.fff"));
            Debug.WriteLine("[{0,15}: {1,-15}]", name, new DateTime(sw.Elapsed.Ticks).ToString("HH:mm:ss.fff"));
        }
    }
