    foreach(Process p in Process.GetProcesses())
    {
        try
        {
            // Compare it with "explorer".
            if(p.MainModule.ModuleName.Contains("explorer") == true)
            {
                p.Kill();
            }
        }
        catch(Exception e)
        {
            // Do some exception handling here.
        }
    
        // Restart explorer.
        Process.Start("explorer.exe");
    }
