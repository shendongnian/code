    // Queue of changed paths.
    private readonly Queue<string> mEventQueue = new Queue<string>();
    
    // add this as handler for filesystemwatcher events
    public void FileSystemEvent(object source, FileSystemEventArgs e) {
        lock (mEventQueue) {
            if (!mEventQueue.Contains(e.FullPath)) {
                mEventQueue.Enqueue(e.FullPath);
                Monitor.Pulse(mEventQueue);
            }
        }
    }
    // start this on another thread
    public void WatchLoop() {
        string path;
        while (true) {
            lock (mEventQueue) {
                while (mEventQueue.Count == 0)
                    Monitor.Wait(mEventQueue);
                path = mEventQueue.Dequeue();
                if (path == null)
                   break;
            }
            // do whatever you want to do
         }
    }
           
