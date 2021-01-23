        using System.Diagnostics;
        
        //...
    
        Process[] all = Process.GetProcesses();
        foreach (Process thisProc in all) {
          string Name = thisProc.ProcessName;
          //...
        }
