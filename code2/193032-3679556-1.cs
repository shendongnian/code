    using System;
    using System.Diagnostics;
    
    class StartupWatch
    {
        static void Main()
        {
            string application = "calc.exe";
            Stopwatch sw = Stopwatch.StartNew();
            Process process = Process.Start(application);
            process.WaitForInputIdle();
            Console.WriteLine("Time to start {0}: {1}", application, sw.Elapsed);
        }
    }
