    Process[] processes in Process.GetProcesses();
    foreach(Process pr in processes.Where(p => p.ProcessName == "****ProcessName"))
    {
    pr.Kill();
    }
