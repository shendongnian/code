    private readonly object syncLock = new object();
    public static void Log(string value) {
        lock(syncLock) {
            //...
        }
    }
