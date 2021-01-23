    public class Publisher
        : IDisposable
    {
        private EventHandler _somethingHappened;
        public event EventHandler SomethingHappened
        {
            add { _somethingHappened += value; }
            remove { _somethingHappened -= value; }
        }
        protected void OnSomethingHappened(object sender, EventArgs e)
        {
            if (_somethingHappened != null)
                _somethingHappened(sender, e);
        }
    
        public void Dispose()
        {
            _somethingHappened = null;
        }
    }
