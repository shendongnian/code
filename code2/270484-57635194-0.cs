    public bool tryFindAnotherInstance(out Process process) {
        Process thisProcess = Process.GetCurrentProcess();
        string thisFilename = thisProcess.MainModule.FileName;
        int thisPId = thisProcess.Id;
        foreach (Process p in Process.GetProcesses())
        {
            try
            {
                if (p.MainModule.FileName == thisFilename && thisPId != p.Id)
                {
                    process = p;
                    return true;
                }
            }
            catch (Exception)
            {
                
            }
        }
        process = default;
        return false;
    }
