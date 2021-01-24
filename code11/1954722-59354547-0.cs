    using System;
    using System.Threading;
    namespace CoreConsole
    {
        public sealed class ThreadData
        {
            public ThreadData(CountdownEvent countdown, int index)
            {
                Countdown = countdown;
                Index     = index;
            }
            public CountdownEvent Countdown { get; }
            public int Index { get; }
        }
        public static class Program
        {
            static void Main()
            {
                int n = 20;
                var countdown  = new CountdownEvent(n);
                for (int task = 0; task < n; task++)
                {
                    ThreadPool.QueueUserWorkItem(TaskCallBack, new ThreadData(countdown, task));
                }
                Console.WriteLine("Waiting for all threads to exit");
                countdown.Wait();
                Console.WriteLine("Waited for all threads to exit");
            }
            public static void TaskCallBack(object state)
            {
                var data = (ThreadData) state;
                Console.WriteLine($"Thread {data.Index} is starting.");
                Thread.Sleep(_rng.Next(2000, 10000));
                data.Countdown.Signal();
                Console.WriteLine($"Thread {data.Index} has finished.");
            }
            static readonly Random _rng = new Random(45698);
        }
    }
