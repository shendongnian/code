    namespace UnityAsyncAwaitUtil
    {
        public static class SyncContextUtil
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            [InitializeOnLoadMethod]
            static void Install()
            {
                UnitySynchronizationContext = SynchronizationContext.Current;
                UnityThreadId = Thread.CurrentThread.ManagedThreadId;
            }
    
            public static int UnityThreadId
            {
                get; private set;
            }
    
            public static SynchronizationContext UnitySynchronizationContext
            {
                get; private set;
            }
        }
    }
