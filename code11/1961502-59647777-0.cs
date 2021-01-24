    Static void Main()
    {
        KillProcess("A_Program");
    }
    private static void KillProcess(string processName)
    {
        Process[] runningProcesses = Process.GetProcesses();
        foreach (Process process in runningProcesses)
        {
            if (process.ProcessName == processName)
            {
                process.Kill();
            }
        }
    }
