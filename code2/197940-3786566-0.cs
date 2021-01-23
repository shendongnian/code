    Process process = ...
    bool hasUI = false;
    if (!process.HasExited)
    {
        try
        {
            hasUI = process.MainWindowHandle != IntPtr.Zero;
        }
        catch (InvalidOperationException)
        {
            if (!process.HasExited)
                throw;
        }
    }
    if (!process.HasExited && hasUI)
    {
            
        try
        {
            process.WaitForInputIdle(100);
        }
        catch (InvalidOperationException)
        {
            if (!process.HasExited)
                throw;
        }
    }
