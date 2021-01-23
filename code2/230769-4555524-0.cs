    public class ConcurrentQueue<T> : ICollection, IEnumerable<T>
    {
        private readonly Queue<T> _queue;
        public ConcurrentQueue()
        {
            _queue = new Queue<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            lock (SyncRoot)
            {
                foreach (var item in _queue)
                {
                    yield return item;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            lock (SyncRoot)
            {
                ((ICollection)_queue).CopyTo(array, index);
            }
        }
        public int Count
        {
            get
            { 
                // Assumed to be atomic, so locking is unnecessary
                return _queue.Count;
            }
        }
        public object SyncRoot
        {
            get { return ((ICollection)_queue).SyncRoot; }
        }
        public bool IsSynchronized
        {
            get { return true; }
        }
        public void Enqueue(T item)
        {
            lock (SyncRoot)
            {
                _queue.Enqueue(item);
            }
        }
        public T Dequeue()
        {
            lock(SyncRoot)
            {
                return _queue.Dequeue();
            }
        }
        public T Peek()
        {
            lock (SyncRoot)
            {
                return _queue.Peek();
            }
        }
        
        public void Clear()
        {
            lock (SyncRoot)
            {
                _queue.Clear();
            }
        }
    }
