    public class SpecialQueue<T>
    {
        private int capacity;
        private Queue<T> storage;
    
        public SpecialQueue(int capacity)
        {
            this.capacity = capacity;
            storage = new Queue<T>();
            // if (capacity <= 0) throw something
        }
    
        public void Push(T value)
        {
            if (storage.Count == capacity)
                storage.Dequeue();
            storage.Enqueue(value);
        }
    
        public T Pop()
        {
            if (storage.Count == 0)
                throw new SomeException("Queue is empty");
            return storage.Dequeue();
        }
    
        public int Count
        {
            get { return storage.Count; }
        }
    }
