    class ConcurrentFixedSizeQueue<T> : IProducerConsumerCollection<T>, IReadOnlyCollection<T>, ICollection {
        readonly ConcurrentQueue<T> m_concurrentQueue;
        readonly int m_maxSize;
        public int Count => m_concurrentQueue.Count;
        public bool IsEmpty => m_concurrentQueue.IsEmpty;
        public ConcurrentFixedSizeQueue (int maxSize) : this(Array.Empty<T>(), maxSize) { }
        public ConcurrentFixedSizeQueue (IEnumerable<T> initialCollection, int maxSize) {
            if (initialCollection == null) {
                throw new ArgumentNullException(nameof(initialCollection));
            }
            m_concurrentQueue = new ConcurrentQueue<T>(initialCollection);
            m_maxSize = maxSize;
        }
        public void Enqueue (T item) {
            m_concurrentQueue.Enqueue(item);
            if (m_concurrentQueue.Count > m_maxSize) {
                T result;
                m_concurrentQueue.TryDequeue(out result);
            }
        }
        public void TryPeek (out T result) => m_concurrentQueue.TryPeek(out result);
        public bool TryDequeue (out T result) => m_concurrentQueue.TryDequeue(out result);
        public void CopyTo (T[] array, int index) => m_concurrentQueue.CopyTo(array, index);
        public T[] ToArray () => m_concurrentQueue.ToArray();
        
        public IEnumerator<T> GetEnumerator () => m_concurrentQueue.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();
        // Explicit ICollection implementations.
        void ICollection.CopyTo (Array array, int index) => ((ICollection)m_concurrentQueue).CopyTo(array, index);
        object ICollection.SyncRoot => ((ICollection) m_concurrentQueue).SyncRoot;
        bool ICollection.IsSynchronized => ((ICollection) m_concurrentQueue).IsSynchronized;
        // Explicit IProducerConsumerCollection<T> implementations.
        bool IProducerConsumerCollection<T>.TryAdd (T item) => ((IProducerConsumerCollection<T>) m_concurrentQueue).TryAdd(item);
        bool IProducerConsumerCollection<T>.TryTake (out T item) => ((IProducerConsumerCollection<T>) m_concurrentQueue).TryTake(out item);
        public override int GetHashCode () => m_concurrentQueue.GetHashCode();
        public override bool Equals (object obj) => m_concurrentQueue.Equals(obj);
        public override string ToString () => m_concurrentQueue.ToString();
    }
