    public class UIContext
    {
        private static TaskScheduler m_Current;
        public static TaskScheduler Current
        {
            get { return m_Current; }
            private set { m_Current = value; }
        }
        public static void Initialize()
        {
            if (Current != null)
                return;
            if (SynchronizationContext.Current == null)
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            Current = TaskScheduler.FromCurrentSynchronizationContext();
        }
    }
