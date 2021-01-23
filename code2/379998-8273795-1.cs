    public class OverflowCollection<T> : IEnumerable<T>
    {
        private int max;
        private LinkedList<T> list = new LinkedList<T>();
        public OverflowCollection(int maxItems)
        {
            this.max = maxItems;
        }
        public void Add(T item)
        {
            this.list.AddFirst(item);
            if (this.list.Count > max)
               this.list.RemoveLast();
        }
        // Implement IEnumerable<T> by returning list's enumerator...
    }
