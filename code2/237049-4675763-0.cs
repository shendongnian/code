    public class DoubleQueue<T>
    {
        private Queue<T> NewItems = new Queue<T>();
        private Queue<T> RetryItems = new Queue<T>();
    
        public Enqueue(T item, bool isNew)
        {
            if (isNew)
                NewItems.Enqueue(item);
            else
                RetryItems.Enqueue(item);
        }
    
        public T Dequeue()
        {
            if (NewItems.Count > 0)
                return NewItems.Dequeue();
            else
                return RetryItems.Dequeue();
        }
    }
