    class UniqueQueue<T> where T:class
    {
        private readonly bool _isReplacementQueue;
        private readonly Queue<T> _queue;
        private readonly HashSet<T> _hashSet;
        public UniqueQueue(): this(false)
        {
        }
        public UniqueQueue(bool isReplacementQueue)
        {
            _isReplacementQueue = isReplacementQueue;
            _queue = new Queue<T>();
            _hashSet = new HashSet<T>();
        }
        public void Enqueue(T item)
        {
            if(!_hashSet.Contains(item))
            {
                _hashSet.Add(item);
               _queue.Enqueue(item);
            }
            else
            {
                if(_isReplacementQueue)
                {
                    //This operation may be pool performance, of which the complexity is the O(n).
                    //if this is not accepted, the queue object should be designed manually.
                    var existedItem = _queue.Single(i => i == item);
                    //TODO: copy the item to the existedItem. 
                    //To do this, T type should be a reference type(class).
                }
            }
        }
        public T Dequeue()
        {
            var item = _queue.Dequeue();
            _hashSet.Remove(item);
            return item;
        }
    }
