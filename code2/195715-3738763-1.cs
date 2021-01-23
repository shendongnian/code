    bool exitProgram = false;
    AutoResetEvent resetEvent = new AutoResetEvent();
    void Main()
    {
        while (!exitProgram)
        {
            Watch(); // Starts FileSystemWatcher
            resetEvent.WaitOne();
        }
    }
    void WorkFinished() // Call at the end of FileSystemWatcher's event handler
    {
         resetEvent.Set(); // This "reschedules" the watcher...
    }
