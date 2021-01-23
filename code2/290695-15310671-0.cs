    static void Main(string[] args)
    {
    FileSystemWatcher fsw = new FileSystemWatcher(FolderToMonitor)
                                {
                                    InternalBufferSize = 65536
                                };
    fsw.EnableRaisingEvents = true;
    fsw.Created += new FileSystemEventHandler(fsw_Created);
    bool monitor = true;
    Show("Waiting...", ConsoleColor.Green);
    while (monitor)
    {
        fsw.WaitForChanged(WatcherChangeTypes.All, 2000); // Abort after 2 seconds to see if there has been a user keypress.
        if (Console.KeyAvailable)
        {
            monitor = false;
        }
    }
    Show("User has quit the process...", ConsoleColor.Yellow);
    Console.ReadKey();
}
