    public class RtdServer : IRtdServer
    {
        private IRTDUpdateEvent _rtdUpdateEvent;
        private SynchronizationContext synchronizationContext;
        public int ServerStart( IRTDUpdateEvent rtdUpdateEvent )
        {
            this._rtdUpdateEvent = rtdUpdateEvent;
            synchronizationContext = new DispatcherSynchronizationContext();
            _timer = new Timer(delegate { PostUpdateNotify(); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return 1;
        }
        // Notify Excel of updated results
        private void PostUpdateNotify()
        {
            // Must only call rtdUpdateEvent.UpdateNotify() from the thread that calls ServerStart.
            // Use synchronizationContext which captures the thread dispatcher.
            synchronizationContext.Post( delegate(object state) { _rtdUpdateEvent.UpdateNotify(); }, null);
        }
        
        // etc
    } // end of class
