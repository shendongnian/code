    private void KillProcessesWithName(string processName) {
        var processesToKill = Process.GetProcesses()
                                     .Where(p => p.ProcessName == processName);
        foreach(var process in processesToKill) {
            process.Kill();
        }
    }
