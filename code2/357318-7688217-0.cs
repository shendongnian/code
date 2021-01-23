    public bool IsProcessRunning(string name)
    {
        //here we're going to get a list of all running processes on
        //the computer
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.StartsWith(name))
            {
                //process found so it's running so return true
                return true;
            }
        }
        //process not found, return false
        return false;
    }
