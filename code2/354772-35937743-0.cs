    internal sealed class AppSettings
    {
        private static readonly AppSettings instance;
        private static ConcurrentDictionary<int, AppSettings> threadedInstances;
        private string _setting1;
        private string _setting2;
        static AppSettings() { instance = new AppSettings(); }
        internal AppSettings(string setting1 = null, string setting2 = null) {
            _setting1 = setting1 != null ? setting1 : Properties.Settings.Default.Setting1;
            _setting2 = setting2 != null ? setting2 : Properties.Settings.Default.Setting2;
        }
        internal static AppSettings Instance {
            get {
                if (threadedInstances != null) {
                    AppSettings threadedInstance;
                    if (threadedInstances.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadedInstance)) {
                        return threadedInstance;
                    }
                }
                return instance;
            }
            set {
                if (threadedInstances == null) {
                    lock (instance) {
                        if (threadedInstances == null) {
                            int numProcs = Environment.ProcessorCount;
                            int concurrencyLevel = numProcs * 2;
                            threadedInstances = new ConcurrentDictionary<int, AppSettings>(concurrencyLevel, 5);
                        }
                    }
                }
                if (value != null) {
                    threadedInstances.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, value, (key, oldValue) => value);
                } else {
                    AppSettings threadedInstance;
                    threadedInstances.TryRemove(Thread.CurrentThread.ManagedThreadId, out threadedInstance);
                }
            }
        }
        internal static string Setting1 => Instance._setting1;
        internal static string Setting2 => Instance._setting2;
    }
