    public class FixedSizedQueue<T> : Queue<T>
    {
        private readonly int maxQueueSize;
        private readonly object syncRoot = new object();
        public FixedSizedQueue(int maxQueueSize)
        {
            this.maxQueueSize = maxQueueSize;
        }
        public new void Enqueue(T item)
        {
            lock (syncRoot)
            {
                base.Enqueue(item);
                if (Count > maxQueueSize)
                    Dequeue(); // Throw away
            }
        }
    }
