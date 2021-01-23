    var semaphore = new Semaphore(0, 1, KeepAliveStarter.SEMAPHORE_NAME);
    DateTime lastChanged = DateTime.MinValue;
    FileSystemEventHandler codeChanged = delegate
    {
        if ((DateTime.Now - lastChanged).TotalSeconds < 2)
            return;
        lastChanged = DateTime.Now;
        Action copyToStopCurrentProcess = onStop;
        onStop = CreateDomainAndStartExecuting();
        ThreadPool.QueueUserWorkItem(delegate
        {
            copyToStopCurrentProcess();
        });
    };
    FileSystemWatcher watcher = new FileSystemWatcher(CODEPATH, ASSEMBLY_NAME + ".dll");
    watcher.Changed += codeChanged;
    watcher.Created += codeChanged;
    onStop = CreateDomainAndStartExecuting();
    
    watcher.EnableRaisingEvents = true;
    semaphore.WaitOne();
    onStop();
}
