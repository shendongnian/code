    while (true)
    {
        SynchronizationResult result =
            session.SynchronizeDirectories(
                SynchronizationMode.Local, "/remote/path", @"C:\local\path", true);
        result.Check();
        // You can inspect result.Downloads for a list for updated files
        Console.WriteLine("Sleeping 10s...");
        Thread.Sleep(10000);
    }
