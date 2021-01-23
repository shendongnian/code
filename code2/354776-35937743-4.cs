    internal sealed class AppSettings
    {
        private static readonly AppSettings instance;
        private static ConcurrentDictionary<int, AppSettings> threadInstances;
        private string _setting1;
        private string _setting2;
        static AppSettings() { instance = new AppSettings(); }
        internal AppSettings(string setting1 = null, string setting2 = null) {
            _setting1 = setting1 != null ? setting1 : Properties.Settings.Default.Setting1;
            _setting2 = setting2 != null ? setting2 : Properties.Settings.Default.Setting2;
        }
        internal static AppSettings Instance {
            get {
                if (threadInstances != null) {
                    AppSettings threadInstance;
                    if (threadedInstances.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInstance)) {
                        return threadInstance;
                    }
                }
                return instance;
            }
            set {
                if (threadInstances == null) {
                    lock (instance) {
                        if (threadInstances == null) {
                            int numProcs = Environment.ProcessorCount;
                            int concurrencyLevel = numProcs * 2;
                            threadInstances = new ConcurrentDictionary<int, AppSettings>(concurrencyLevel, 5);
                        }
                    }
                }
                if (value != null) {
                    threadInstances.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, value, (key, oldValue) => value);
                } else {
                    AppSettings threadInstance;
                    threadInstances.TryRemove(Thread.CurrentThread.ManagedThreadId, out threadInstance);
                }
            }
        }
        internal static string Setting1 => Instance._setting1;
        internal static string Setting2 => Instance._setting2;
    }
