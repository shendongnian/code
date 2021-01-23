    public class ConsoleAutoStopWatch : IDisposable
    {
        private readonly Stopwatch _stopWatch;
     
        public ConsoleAutoStopWatch()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }
     
        public void Dispose()
        {
            _stopWatch.Stop();
            TimeSpan ts = _stopWatch.Elapsed;
     
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                               ts.Hours, ts.Minutes, ts.Seconds,
                                               ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");
        }
    }
    private static void UsingStopWatchUsage()
    {
        Console.WriteLine("ConsoleAutoStopWatch Used: ");
        using (new ConsoleAutoStopWatch())
        {
            Thread.Sleep(3000);
        }
    }
