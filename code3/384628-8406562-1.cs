        System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcesses();
        foreach(Process theprocess in proc)
        {
          Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
        }
