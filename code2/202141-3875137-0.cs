    public static bool KillProcess(string name)
    {
        var processes = System.Diagnostics.Process.GetProcesses();
        var process = processes.SingleOrDefault(p => p.ProcessName == name);
        if (process != null)
        {
            process.Kill();
            return true;
        }
        return false;
    }
