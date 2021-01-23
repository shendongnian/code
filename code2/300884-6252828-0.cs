    public static void Retry(Action fileAction, int iteration)
    {
        try
        {
            fileAction.Invoke();
        }
        catch (IOException)
        {
            if (interation < MaxRetries)
            {
                System.Threading.Thread.Sleep(IterationThrottleMS);
                Retry(fileAction, ++iteration);
            }
            else
            {
                throw;
            }
        }
    }
