    public interface IContext
    {
        void Post(SendOrPostCallback d, Object state);
    }
    public class SynchronizationContextAdapter : IContext
    {
        private SynchronizationContext _context;
        public SynchronizationContextAdapter(SynchronizationContext context)
        {
            _context = context;
        }
        public virtual void Post(SendOrPostCallback d, Object state)
        {
            _context.Post(d, state);
        }
    }
    public class SomeClass
    {
        public SomeClass(IContext context)
        {
            _context = context;
        }
        void _tracker_IndexChanged(object sender, IndexTrackerChangedEventArgs e)
        {
            _context.Post(o => _view.SetTrackbarValue(_tracker.Index), null);
        }
        // ...
    }
