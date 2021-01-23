    //This method is called exactly once.
    protected internal virtual void OnCompleted(string result) {
        Result = result;
        isCompleted = true;
        waiter.Set();
        Thread.MemoryBarrier();
        if (waitingCount == 0) {
            waiter.Dispose();
        }
    }
