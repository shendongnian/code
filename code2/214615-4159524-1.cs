        if(CheckForSomething())
        {
            try
            {
                // do something
            }
            catch (UnauthorizedAccessException ex)
            {
                LogException(ex);
            }
            catch (Exception ex) // Never do this.  Do you know how to handle an OutOfMemoryException?
            {
                LogException(ex);
            }
        }
        else
        {
            string error = "Some error";
            LogMessage(error);
        }
    
    private static void LogException(Exception ex)
    {
        // write ex to one log file
        LogMessage(ex.Message);
    }
    
    private static void LogMessage(string message)
    {
        // write message to another log file
    }
