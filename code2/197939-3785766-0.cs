    Process process = ...
    try
    {
        process.WaitForInputIdle(100);
    }
    catch (InvalidOperationException ex)
    {
        // no graphical interface
    }
