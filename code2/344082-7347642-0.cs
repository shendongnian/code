	using System;
	using System.Diagnostics;
	using System.Threading;
	
	class Watchdog 
	{
		static void Main(string[] args)
        {
        	while(true) {
        		if (!IsRdpRunning())
        			RunRdp();
        		Thread.Sleep(1000);
        	}
        }
        private static void RunRdp()
        {
            Process rdp = new Process();
            rdp.StartInfo = new ProcessStartInfo(@"C:\Alistair\Default.rdp");
            rdp.Start();
       		Thread.Sleep(10000);
        }
        private static bool IsRdpRunning()
        {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains("mstsc"))
                    {
                    	return true;
                    }
                }
                return false;
        }
	}
