    //get all other (possible) running instances
    Process[] processes = Process.GetProcesses();
    try
    {
        foreach (Process proc in processes)
        {
        // use proc
        }
    }
    finally
    {
        foreach (Process proc in processes)
            proc.Dispose();
        processes = null;
    }
