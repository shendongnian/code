    using System;
    using System.Diagnostics;
    public static class MethodTimer
    {
        public static double CalcTime(Action action)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            action();
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds;
        }
    }
