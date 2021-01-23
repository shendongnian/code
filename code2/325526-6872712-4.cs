    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime;
    using System.Runtime.CompilerServices;
    using System.Security;
    public class MainClass
    {
        public static void Main()
        {
            Process[] allProcs = Process.GetProcesses("RemoteMachineOnYourNetwork");
            foreach (Process p in allProcs) 
               Console.WriteLine("  -> {0} - {1}", p.ProcessName, p.PeakWorkingSet64);
        }
    }
