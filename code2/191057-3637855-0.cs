    class MessagePump<T>
    {
        private T _obj;
        private BlockingCollection<Action<T>> _workItems;
        private Thread _thread;
    
        public MessagePump(T obj)
        {
            // Note: the default underlying data store for a BlockingCollection<T>
            // is a ConcurrentQueue<T>, which is what we want.
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
                    // this thread is always running.
                }
            }
        }
    }
