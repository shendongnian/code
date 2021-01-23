    public class SetQueue<T>
        {
            private readonly Dictionary<T, bool> duplicates = new Dictionary<T, bool>();
            private readonly Queue<T> queue = new Queue<T>();
    
            public bool Enqueue(T item)
            {
                if (!duplicates.ContainsKey(item))
                {
                    duplicates[item] = true;
    
                    queue.Enqueue(item);
    
                    return true;
                }
    
                return false;
            }
    
            public T Dequeue()
            {
                if (queue.Count >0)
                {
                    return queue.Dequeue();
                }
    
                throw new InvalidOperationException("Can't dequeue on an empty queue.");
            }
        }
