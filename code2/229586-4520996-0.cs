    public class SpecialQueue<T> : IEnumerable<T>, ICollection
    {
        private readonly Queue<T> _queue;
        #region Constructors
        public SpecialQueue()
        {
            _queue = new Queue<T>();
        }
        public SpecialQueue(int capacity)
        {
            _queue = new Queue<T>(capacity);
        }
        public SpecialQueue(IEnumerable<T> collection)
        {
            _queue = new Queue<T>(collection);
        }
        #endregion
        #region Methods
        // implement any methods that you want public here...
        #endregion
        #region Interface Implementations
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            ((ICollection) _queue).CopyTo(array, index);
        }
        public int Count
        {
            get { return _queue.Count; }
        }
        public object SyncRoot
        {
            get { return ((ICollection) _queue).SyncRoot; }
        }
        public bool IsSynchronized
        {
            get { return ((ICollection) _queue).IsSynchronized; }
        }
        #endregion
    }
