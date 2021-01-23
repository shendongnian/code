    var processes = Process.GetProcessesByName("yourProcessName");
    if(processes.Length == 0)
    {
        Process.Start(@"C:\Path\To\Your\Process.exe");
    }
    // Kill the extras
    for(int i = 1; i < process.Length; i++)
    {
        processes[i].Kill();
    }
