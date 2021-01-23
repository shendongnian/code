    public class FixedSizedQueue<T>
    {
        readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        public int Size { get; private set; }
        public FixedSizedQueue(int size)
        {
            Size = size;
        }
        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);
            while (queue.Count > Size)
            {
                T outObj;
                queue.TryDequeue(out outObj);
            }
        }
    }
