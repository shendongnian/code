    #if DEBUG
    public static ConcurrentList<object> list = new ConcurrentList<object>();
    #else
    private static ConcurrentList<object> list = new ConcurrentList<object>();
    #endif
