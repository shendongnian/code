    if(CheckForSomething())
    {
        try
        {
            // do something
        }
        catch (UnauthorizedAccessException ex)
        {
            LogMessage(ex.Message);
        }
    }
    else
    {
        LogMessage("Some Error!");
    }
    private static void LogMessage(string message)
    {
      //write message to log
    }
