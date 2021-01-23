    public class QueueWaitHandle<T> : WaitHandle
    {
        private Queue<T> queue = new Queue<T>();
        private ManualResetEvent signal = new ManualResetEvent(false);
    
        public QueueWaitHandle()
        {
            base.SafeWaitHandle = signal.SafeWaitHandle;
        }
    
        public void Enqueue(T item)
        {
            lock (queue)
            {
                queue.Enqueue(item);
                signal.Set();
            }
        }
    
        public T Dequeue()
        {
            lock (queue)
            {
                T item = queue.Dequeue();
                if (queue.Count == 0)
                {
                    signal.Reset();
                }
                return item;
            }
        }
    }
