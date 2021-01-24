    if(Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Length > 1)
    {
        foreach (var process in Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)))
        {
            if (process.Id != Process.GetCurrentProcess().Id)
            {
                process.Kill();
            }
        }
    }
