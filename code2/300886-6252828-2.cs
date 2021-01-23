    const int IterationThrottleMS = 1000;
    const int MaxRetries = 5;
    public static void Retry(Action fileAction)
    {
        Retry(fileAction, 1)
    }
    ...
    
