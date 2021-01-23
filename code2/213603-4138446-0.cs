    public class SyncOrchestrator
    {
        // ...
        public event EventHandler<MyEventArgs> SessionProgress;
        protected virtual void OnSessionProgress(MyEventArgs e)
        {
            // Note the use of a temporary variable here to make the event raisin
            // thread-safe; may or may not be necessary in your case.
            var evt = this.SessionProgress;
            if (evt  != null)
                evt (this, e);
        }
        // ...
    }
