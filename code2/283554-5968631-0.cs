    System.Threading.Timer t;
    bool timeout;
    
    [...]
    // Initialization
    t = new Timer((s) => {
        lock (this) {
            timeout = true;
            Disconnected();
        }
    });
    [...]
    // Before each asynchronous socket operation
    t.Change(10000, System.Threading.Timeout.Infinite);
    [...]
    // In the callback of the asynchronous socket operations
    lock (this) {
        t.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        if (!timeout) {
            // Perform work
        }
    }
