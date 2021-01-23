    //the UniqueQueueItem has the key in itself,
    //and implements the IUniqueQueueItemable to copy the other values.
    //For example:
    class TestUniqueQueueItem : IUniqueQueueItemable<TestUniqueQueueItem>
    {
        //Key
        public int Id { get; set; }
        public string Name { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
        //To copy the other values.
        public void CopyWith(TestUniqueQueueItem item)
        {
            this.Name = item.Name;
        }
        public override bool Equals(object obj)
        {
            return this.Id == ((TestUniqueQueueItem)obj).Id;
        }
    }
    internal interface IUniqueQueueItemable<in T>
    {
        void CopyWith(T item);
    }
    class UniqueQueue<T> where T: IUniqueQueueItemable<T>
    {
        private readonly bool _isReplacementQueue;
        private readonly Queue<T> _queue;
        private readonly Dictionary<T, T> _dictionary;
        public UniqueQueue(): this(false)
        {
        }
        public UniqueQueue(bool isReplacementQueue)
        {
            _isReplacementQueue = isReplacementQueue;
            _queue = new Queue<T>();
            _dictionary = new Dictionary<T, T>();
        }
        public void Enqueue(T item)
        {
            if(!_dictionary.Keys.Contains(item))
            {
                _dictionary.Add(item, item);
               _queue.Enqueue(item);
            }
            else
            {
                if(_isReplacementQueue)
                {
                    //it will return the existedItem, which is the same key with the item 
                    //but has different values with it.
                    var existedItem = _dictionary[item];
                    //copy the item to the existedItem. 
                    existedItem.CopyWith(item);
                }
            }
        }
        public T Dequeue()
        {
            var item = _queue.Dequeue();
            _dictionary.Remove(item);
            return item;
        }
    }
