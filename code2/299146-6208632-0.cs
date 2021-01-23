    bool isLaunching = false;
    object launchingLock = new object();
    Process p = null;
    Timer timer = new Timer(new TimerCallback((state) =>
    {
        lock (launchingLock)
        {
            if (isLaunching)
            {
                if (p != null && p.HasExited == false && p.Id != 0)
                {
                    // Success! 
                    isLaunching = false;
                    Monitor.PulseAll(launchingLock);
                }
                else if(p != null && p.HasExited)
                {
                    // Some sort of failure code/notification?
                    // We still want to pulse though, otherwise thread will be forever kept waiting
                    isLaunching = false;
                    Monitor.PulseAll(launchingLock);
                }
            }
        }
    }));
    timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
    foreach (string url in urls)
    {
        try
        {
            lock (launchingLock)
            {
                isLaunching = true;
                p = new Process();
                p.StartInfo.FileName = browser;
                p.StartInfo.Arguments = url;
                p.Start();
                // Wait until the process has finished starting before moving on
                Monitor.Wait(launchingLock);
            }
        }
        catch (Exception ex)
        {
            // something
        }
    }
    timer.Dispose();
