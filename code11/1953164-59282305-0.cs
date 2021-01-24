    var runningProcess = System.Diagnostics.Process.GetProcessesByName("firefox");
    if (runningProcess.Length != 0)
    {
        System.Diagnostics.Process.Start("firefox", filename);
    }
