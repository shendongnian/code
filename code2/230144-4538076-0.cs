    using System;
    using System.Threading;
    using System.Timers;
    using Timer = System.Timers.Timer;
    namespace CpuLoad
    {
        internal class Program
        {
            private static int cpuload;
            private static readonly AutoResetEvent autoEvent = new AutoResetEvent(false);
            private static void Main(string[] args)
            {
                var timer = new Timer(3000);
                timer.Elapsed += CheckCPULoad;
                timer.Start();
                while (true)
                {
                    autoEvent.WaitOne();
                    autoEvent.Reset();
                    Console.WriteLine(cpuload);
                }
            }
            private static void CheckCPULoad(object sender, ElapsedEventArgs e)
            {
                cpuload++;
                autoEvent.Set();
            }
        }
    }
