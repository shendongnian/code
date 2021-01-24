    var acquiredImmediately = Monitor.TryEnter(...); //test lock
    if (!acquiredImmediately) {
        Log(...);
        Monitor.Enter(...); //retry by blocking
    }
    CriticalRegion();
    Monitor.Exit();
