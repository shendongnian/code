    int errorCount = 0;
    bool success = false;
    while (!success || errorCount < maxRetryCount)
    {
        try
        {
             /* Call to WMI interface */
             DoSomething();
             success = true;
        }
        catch (Exception ex)
        {
             if (errorCount < maxRetryCount)
             {
                 logWarning(ex);
             }
             else
             {
                 logError(ex);
                 throw; /* pass exception up the stack 
                 or break and handle failure below */
             }
        }
    }
    if (!success)
    {
        /* Handle failure */
    }
 
 
