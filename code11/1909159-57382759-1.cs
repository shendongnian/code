    namespace UnityAsyncAwaitUtil
    {
        public static class SyncContextUtil
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            [InitializeOnLoadMethod]
            static void Install()
            {
                // As suggested by @derHugo you can add a null check here
                // which will prevent initializing these parameters twice
                // see his comment for more info
                if (UnitySynchronizationContext == null) {
                  UnitySynchronizationContext = SynchronizationContext.Current;
                }
                if (UnityThreadId == null) {
                  UnityThreadId = Thread.CurrentThread.ManagedThreadId;
                }
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
