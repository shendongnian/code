    public sealed class SizedQueue<T> : Queue<T>
    {
        public int FixedCapacity { get; }
        public SizedQueue(int fixedCapacity)
        {
            this.FixedCapacity = fixedCapacity;
        }
    
        /// <summary>
        /// If the total number of item exceed the capacity, the oldest ones automatically dequeues.
        /// </summary>
        /// <returns>The dequeued value, if any.</returns>
        public new T Enqueue(T item)
        {
            this.Enqueue(item);
            if (this.Count > FixedCapacity)
            {
                return this.Dequeue();
            }
            return default;
        }
    }
