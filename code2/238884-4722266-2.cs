    bool IsRunning = true;
    using (Mutex mutex = new Mutex(true, "AppUniqueName", out IsRunning))
    {
        if (IsRunning)
        {
            Application.Run(new YourMainClass());
        }
    }
