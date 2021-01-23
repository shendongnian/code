    class MyBackgroundQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        private System.Threading.AutoResetEvent _event = new System.Threading.AutoResetEvent(false);
        private System.Threading.Thread _thread;
        public void Start()
        {
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(ProcessQueueWorker));
            _thread.Start();
        }
        public class ItemEventArgs : EventArgs
        { public T Item { get; set; } }
        public event EventHandler<ItemEventArgs> ProcessItem;
        private void ProcessQueueWorker()
        {
            while (true)
            {
                _event.WaitOne();
                while (_queue.Count > 0)
                    ProcessItem(this, new ItemEventArgs { Item = _queue.Dequeue() });
            }
        }
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            _event.Set();
        }
    }
