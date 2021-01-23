    /// <summary>
    /// Defines a sharing violation wrapper delegate.
    /// </summary>
    public delegate void WrapSharingViolationsCallback();
    /// <summary>
    /// Wraps sharing violations that could occur on a file IO operation.
    /// </summary>
    /// <param name="action">The action to execute. May not be null.</param>
    /// <param name="exceptionsCallback">The exceptions callback. May be null.</param>
    /// <param name="retryCount">The retry count.</param>
    /// <param name="waitTime">The wait time in milliseconds.</param>
    public static void WrapSharingViolations(WrapSharingViolationsCallback action, WrapSharingViolationsExceptionsCallback exceptionsCallback, int retryCount, int waitTime)
    {
        if (action == null)
            throw new ArgumentNullException("action");
        for (int i = 0; i < retryCount; i++)
        {
            try
            {
                action();
                return;
            }
            catch (IOException ioe)
            {
                if ((IsSharingViolation(ioe)) && (i < (retryCount - 1)))
                {
                    bool wait = true;
                    if (exceptionsCallback != null)
                    {
                        wait = exceptionsCallback(ioe, i, retryCount, waitTime);
                    }
                    if (wait)
                    {
                        Thread.Sleep(waitTime);
                    }
                }
                else
                {
                    throw;
                }
            }
        }
    }
