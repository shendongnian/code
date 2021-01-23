    foreach (Process process in runningNow)
    {
        using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", process.ProcessName))
        using (PerformanceCounter memProcess = new PerformanceCounter("Memory", "Available MBytes"))
        {
            if (process.ProcessName == procName)
            {
                pcProcess.NextValue();
                Thread.Sleep(60000);
                StreamWriter OurStream;
                OurStream = File.AppendText("c:\\CPUMON.txt");
                Console.WriteLine("");
                OurStream.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                float cpuUseage = pcProcess.NextValue();
                Console.WriteLine("Process: '{0}' CPU Usage: {1}%", process.ProcessName, cpuUseage);
                OurStream.WriteLine("Process: '{0}' CPU Usage: {1}%", process.ProcessName, cpuUseage);
                Console.ForegroundColor = ConsoleColor.Green;
                float memUseage = memProcess.NextValue();
                Console.WriteLine("Process: '{0}' RAM Free: {1}MB", process.ProcessName, memUseage);
                OurStream.WriteLine("Process: '{0}' RAM Free: {1}MB", process.ProcessName, memUseage);
                //(snip)
            }
        }
    }
