    class MessagePump<T>
    {
        // In your case you would set this to your Ultrasound object.
        // You could just as easily design this class to be "object-agnostic";
        // but I think that coupling an instance to a specific object makes it clearer
        // what the purpose of the MessagePump<T> is.
        private T _obj;
        private BlockingCollection<Action<T>> _workItems;
        private Thread _thread;
    
        public MessagePump(T obj)
        {
            // Note: the default underlying data store for a BlockingCollection<T>
            // is a FIFO ConcurrentQueue<T>, which is what we want.
            _workItems = new BlockingCollection<Action<T>>();
    
            _thread = new Thread(ProcessQueue);
            _thread.IsBackground = true;
            _thread.Start();
        }
    
        public void Submit(Action<T> workItem)
        {
            _workItems.Add(workItem);
        }
    
        private void ProcessQueue()
        {
            for (;;)
            {
                Action<T> workItem = _workItems.Take();
                try
                {
                    workItem(_obj);
                }
                catch
                {
                    // Put in some exception handling mechanism so that
                    // this thread is always running. One idea would be to
                    // raise an event containing the Exception object on a
                    // threadpool thread. You definitely don't want to raise
                    // the event from THIS thread, though, since then you
                    // could hit ANOTHER exception, which would defeat the
                    // purpose of this catch block.
                }
            }
        }
    }
