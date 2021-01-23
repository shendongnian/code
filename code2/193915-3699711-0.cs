    using System;
    using System.Threading;
    
    namespace ProjectEuler
    {
        class Program
        {
            //const double cycleIntervalMilliseconds = 10 * 60 * 1000;
            const double cycleIntervalMilliseconds = 5 * 1000;
            static readonly System.Timers.Timer scanTimer =
                new System.Timers.Timer(cycleIntervalMilliseconds);
            static bool scanningEnabled = true;
            static readonly ManualResetEvent scanFinished =
                new ManualResetEvent(true);
    
            static void Main(string[] args)
            {
                scanTimer.Elapsed +=
                    new System.Timers.ElapsedEventHandler(scanTimer_Elapsed);
                scanTimer.Enabled = true;
    
                Console.ReadLine();
                scanningEnabled = false;
                scanFinished.WaitOne();
            }
    
            static void  scanTimer_Elapsed(object sender,
                System.Timers.ElapsedEventArgs e)
            {
                scanFinished.Reset();
                scanTimer.Enabled = false;
    
                if (scanningEnabled)
                {
                    try
                    {
                        Console.WriteLine("Processing");
                        Thread.Sleep(5000);
                        Console.WriteLine("Finished");
                    }
                    finally
                    {
                        scanTimer.Enabled = scanningEnabled;
                        scanFinished.Set();
                    }
                }
            }
        }
    }
