    public static void OnChangedByUser(this FileSystemWatcher fsw,
        FileSystemEventHandler handler)
    {
        const int TOLERANCE_MSEC = 100;
        object locker = new object();
        string fileName = null;
        Stopwatch stopwatch = new Stopwatch();
        fsw.Created += OnFileCreated;
        fsw.Changed += OnFileChanged;
        fsw.Disposed += OnDisposed;
        void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            lock (locker)
            {
                fileName = e.Name;
                stopwatch.Restart();
            }
        }
        void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            lock (locker)
            {
                if (e.Name == fileName && stopwatch.ElapsedMilliseconds < TOLERANCE_MSEC)
                {
                    return; // Ignore this event
                }
            }
            handler.Invoke(sender, e);
        }
        void OnDisposed(object sender, EventArgs e)
        {
            fsw.Created -= OnFileCreated;
            fsw.Changed -= OnFileChanged;
            fsw.Disposed -= OnDisposed;
        }
    }
