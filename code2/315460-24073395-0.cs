    public class NoDuplicatesConcurrentQueue<T> : IProducerConsumerCollection<T>
    {
        private readonly ConcurrentDictionary<T, bool> existingElements = new ConcurrentDictionary<T, bool>();
        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        public bool TryAdd(T item)
        {
            if (existingElements.TryAdd(item, false))
            {
                queue.Enqueue(item);
                return true;
            }
            return false;
        }
        public bool TryTake(out T item)
        {
            if (queue.TryDequeue(out item))
            {
                bool _;
                existingElements.TryRemove(item, out _);
                return true;
            }
            return false;
        }
        ...
    }
