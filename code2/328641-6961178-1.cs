    /// <summary>
    /// Kills any instances of Excel that were created by the program.
    /// </summary>
    /// <param name="zInstancesToSave">Instances that were not </param>
    private static void KillExcel(List<Process> zInstancesToSave)
    {
        List<Process> xProcesslist = Process.GetProcesses().ToList<Process>();
        xProcesslist = xProcesslist.FindAll(proc => proc.ProcessName == "EXCEL");
        foreach(Proc process in xProcesslist)
        {
            process.Kill();
        }
    }
