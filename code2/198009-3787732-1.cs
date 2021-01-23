    public class Subscriber
        : IDisposable
    { 
        private Publisher _publisher;
        public Publisher Publisher
        {
            get { return _publisher; }
            set {
                // Detach from the old reference
                DetachEvents(_publisher);
                _publisher = value;
                // Attach to the new
                AttachEvents(_publisher);
            }
        }
    
        private void DetachEvents(Publisher publisher)
        {
            if (publisher != null)
            {
                publisher.SomethingHappened -= new EventHandler(publisher_SomethingHappened);
            }
        }
        private void AttachEvents(Publisher publisher)
        {
            if (publisher != null)
            {
                publisher.SomethingHappened += new EventHandler(publisher_SomethingHappened);
            }
        }
    
        void publisher_SomethingHappened(object sender, EventArgs e)
        {
            // DO STUFF
        }
    
        public void Dispose()
        {
            // Detach from reference
            DetachEvents(Publisher);
        }
    }
