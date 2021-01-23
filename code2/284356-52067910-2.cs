    class FixedSizedConcurrentQueue<T> 
    {
        readonly Queue<T> queue = new Queue<T>();
        readonly object syncObject = new object();
        public int MaxSize { get; private set; }
        public FixedSizedConcurrentQueue(int maxSize)
        {
            MaxSize = maxSize;
        }
        public void Enqueue(T obj)
        {
            lock (syncObject)
            {
                queue.Enqueue(obj);
                while (queue.Count > MaxSize)
                {
                    queue.Dequeue();
                }
            }
        }
        public T[] ToArray()
        {
            T[] result = null;
            lock (syncObject)
            {
                result = queue.ToArray();
            }
            return result;
        }
        public void Clear()
        {
            lock (syncObject)
            {
                queue.Clear();
            }
        }
    }
