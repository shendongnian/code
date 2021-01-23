    Process[] prs = Process.GetProcesses();
    
    
    foreach (Process pr in prs)
    {
    if (pr.ProcessName == "test")
    {
    
    pr.Kill();
    
    }
    
    }
