    private readonly Mutex m = new Mutex();
    public void ThreadSafeMethod() {
        m.WaitOne();
        try {
            /* critical code */
        } finally {
            m.ReleaseMutex();
        }
    }
