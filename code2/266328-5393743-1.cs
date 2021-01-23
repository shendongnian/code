    // the application clock
    Stopwatch AppTime = Stopwatch.StartNew();
    // Amount of time to delay an item
    TimeSpan DelayTime = TimeSpan.FromSeconds(1.0);
    ConcurrentQueue<BufferItem> ItemQueue = new ConcurrentQueue<BufferItem>();
    // Timer will check items for release every 15 ms.
    System.ThreadingTimer ReleaseTimer = new System.Threading.Timer(CheckRelease, null, 15, 15);
