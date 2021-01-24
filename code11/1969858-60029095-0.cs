    using System;
    using System.Diagnostics;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Thread.Sleep(10000);
            long elapsedTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
