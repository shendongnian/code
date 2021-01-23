    // launch threads
    for (int i = 0; i < ThreadCount; i++)
    {
        if (i == 0) {
            Thread t = new Thread(RunGame);
            t.IsBackground = true;
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
            threads.Add(t);
        } else {
            Thread t = new Thread(gtkWindow);
            t.IsBackground = true;
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
            threads.Add(t);
        }
    }
