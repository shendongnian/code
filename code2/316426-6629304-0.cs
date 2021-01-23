    public bool RetryUntilSuccessOrTimeout(Func<bool> task, TimeSpan timeSpan)
    {
        bool success = false;
        int elapsed = 0;
        while ((!success) && (elapsed < timeSpan.TotalMilliseconds))
        {
            Thread.Sleep(1000);
            elapsed += 1000;
            success = task();
        }
        return success;
    }
