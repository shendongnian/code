    public class AsyncQueue<T>
    {
        public bool IsCompleted { get; }
        public Task<T> DequeueAsync();
        public void Enqueue(T item);
        public void FinishAdding();
    }
