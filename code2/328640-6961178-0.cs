    /// <summary>
    /// Gets all currently running instances of Excel, so we don't kill active windows.
    /// </summary>
    private void GetInstancesToSave()
    {
        if (_instancesToSaveList != null)
        {
            _instancesToSaveList.Clear();
        }
        _instancesToSaveList = Process.GetProcesses().ToList<Process>();
        _instancesToSaveList = _instancesToSaveList.FindAll(proc => proc.ProcessName == "EXCEL");
    }
    /// <summary>
    /// Kills any instances of Excel that were created by the program.
    /// </summary>
    /// <param name="zInstancesToSave">Instances that were not </param>
    private static void KillExcel(List<Process> zInstancesToSave)
    {
        List<Process> xProcesslist = Process.GetProcesses().ToList<Process>();
        xProcesslist = xProcesslist.FindAll(proc => proc.ProcessName == "EXCEL");
        foreach (Process xTheprocess in xProcesslist)//read through all running programs
        {
            bool killit = true;
            foreach (Process proc in zInstancesToSave)//read through all running programs
            {
                if (xTheprocess.Id == proc.Id)
                {
                    killit = false;
                }
            }
            if (killit)
            {
                xTheprocess.Kill();
            }
        }
    }
