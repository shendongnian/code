    public bool IsRunning(string ProcessName)
    {
        foreach (System.Diagnostics.Process theProcess in System.Diagnostics.Process.GetProcesses())
        {
            if (theProcess.ProcessName.Contains(ProcessName))
                return true;
        }
        
        return false;
    }
