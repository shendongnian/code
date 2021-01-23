    using System.Threading;
    public class DisposableThreadLocal<T> : IDisposable
        where T : IDisposable
    {
        public DisposableThreadLocal(Func<T> _ValueFactory)
        {
            Initialize(_ValueFactory, false, 1);
        }
        public DisposableThreadLocal(Func<T> _ValueFactory, bool CreateLocalWatcherThread, int _CheckEverySeconds)
        {
            Initialize(_ValueFactory, CreateLocalWatcherThread, _CheckEverySeconds);
        }
        private void Initialize(Func<T> _ValueFactory, bool CreateLocalWatcherThread, int _CheckEverySeconds)
        {
            m_ValueFactory = _ValueFactory;
            m_CheckEverySeconds = _CheckEverySeconds * 1000;
            if (CreateLocalWatcherThread)
            {
                System.Threading.ThreadStart WatcherThreadStart;
                WatcherThreadStart = new ThreadStart(InternalMonitor);
                WatcherThread = new Thread(WatcherThreadStart);
                WatcherThread.Start();
            }
        }
        private object SyncRoot = new object();
        private Func<T> m_ValueFactory;
        public Func<T> ValueFactory
        {
            get
            {
                return m_ValueFactory;
            }
        }
        private Dictionary<Thread, T> m_InternalDict = new Dictionary<Thread, T>();
        private Dictionary<Thread, T> InternalDict
        {
            get
            {
                return m_InternalDict;
            }
        }
        public T Value
        {
            get
            {
                T Result;
                lock(SyncRoot)
                {
                    if (!InternalDict.TryGetValue(Thread.CurrentThread,out Result))
                    {
                        Result = ValueFactory.Invoke();
                        InternalDict.Add(Thread.CurrentThread, Result);
                    }
                }
                return Result;
            }
            set
            {
                lock (SyncRoot)
                {
                    if (InternalDict.ContainsKey(Thread.CurrentThread))
                    {
                        InternalDict[Thread.CurrentThread] = value;
                    }
                    else
                    {
                        InternalDict.Add(Thread.CurrentThread, value);
                    }
                }
            }
        }
        public bool IsValueCreated
        {
            get
            {
                lock (SyncRoot)
                {
                    return InternalDict.ContainsKey(Thread.CurrentThread);
                }
            }
        }
        public void DisposeThreadCompletedValues()
        {
            lock (SyncRoot)
            {
                List<Thread> CompletedThreads;
                CompletedThreads = new List<Thread>();
                foreach (Thread ThreadInstance in InternalDict.Keys)
                {
                    if (!ThreadInstance.IsAlive)
                    {
                        CompletedThreads.Add(ThreadInstance);
                    }
                }
                foreach (Thread ThreadInstance in CompletedThreads)
                {
                    InternalDict[ThreadInstance].Dispose();
                    InternalDict.Remove(ThreadInstance);
                }
            }
        }
        private int m_CheckEverySeconds;
        private int CheckEverySeconds
        {
            get
            {
                return m_CheckEverySeconds;
            }
        }
        private Thread WatcherThread;
        private void InternalMonitor()
        {
            while (!IsDisposed)
            {
                System.Threading.Thread.Sleep(CheckEverySeconds);
                DisposeThreadCompletedValues();
            }
        }
        private bool IsDisposed = false;
        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                DoDispose();
            }
        }
        private void DoDispose()
        {
            if (WatcherThread != null)
            {
                WatcherThread.Abort();
            }
            //InternalDict.Values.ToList().ForEach(Value => Value.Dispose());
            foreach (T Value in InternalDict.Values)
            {
                Value.Dispose();
            }
            InternalDict.Clear();
            m_InternalDict = null;
            m_ValueFactory = null;
            GC.SuppressFinalize(this);
        }
    }
