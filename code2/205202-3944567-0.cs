    public class ImplicitSynchronisationContext : SynchronizationContext
    {
        private readonly SynchronizationContext m_SyncContext;
        public ImplicitSynchronisationContext()
        {
            // Default to the current sync context if available.
            m_SyncContext = SynchronizationContext.Current;
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            if (m_SyncContext != null)
            {
                m_SyncContext.Post(d, state);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(_ => d(state));
            }
        }
        
        public override void Send(SendOrPostCallback d, object state)
        {
            if (m_SyncContext != null)
            {
                m_SyncContext.Send(d, state);
            }
            else
            {
                d(state);
            }
        }
    }
