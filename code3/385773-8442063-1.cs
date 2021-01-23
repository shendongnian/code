    static void Main(string[] args)
    {
        FileSystemWatcher watcher = new FileSystemWatcher(@"f:\");
        ManualResetEvent workToDo = new ManualResetEvent(false);
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        watcher.Changed += (source, e) => { workToDo.Set(); };
        watcher.Created += (source, e) => { workToDo.Set(); };
        // begin watching
        watcher.EnableRaisingEvents = true;
        while (true)
        {
            if (workToDo.WaitOne())
            {
                workToDo.Reset();
                Console.WriteLine("Woken up, something has changed.");
            }
            else
                Console.WriteLine("Timed-out, check if there is any file changed anyway, in case we missed a signal");
            foreach (var file in Directory.EnumerateFiles(@"f:\")) 
                Console.WriteLine("Do your work here");
        }
    }
