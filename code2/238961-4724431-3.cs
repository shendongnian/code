    new Thread(delegate()
        {
            Thread.Sleep(Settings.Default.CheckDelay);
            while (isRunning)
            {
                TimerCallback(null);
                Thread.Sleep(Settings.Default.CheckInterval);
            }
        }).Start();
