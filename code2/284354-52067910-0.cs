    class FixedSizedConcurrentQueue<T> 
    {
        readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
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
                    queue.TryDequeue(out T outObj);
                }
            }
        }
        public T[] ToArray()
        {
            T[] result = null;
            lock (syncObject)
            {
                result = new T[queue.Count];
                queue.CopyTo(result, 0);
            }
            return result;
        }
    }
