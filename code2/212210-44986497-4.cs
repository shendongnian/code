    using Ectx = ExecutionContext;
    using Sctx = SynchronizationContext;
    using Dctx = DispatcherSynchronizationContext;
    public static class _ext
    {
        // DispatcherSynchronizationContext from Dispatcher
        public static Dctx GetSyncCtx(this Dispatcher d) => d?.Thread.GetSyncCtx() as Dctx;
        // SynchronizationContext from Thread
        public static Sctx GetSyncCtx(this Thread th) => th?.ExecutionContext?.GetSyncCtx();
        // SynchronizationContext from ExecutionContext
        public static Sctx GetSyncCtx(this Ectx x) => __get(x);
        /* ... continued below ... */
    }
