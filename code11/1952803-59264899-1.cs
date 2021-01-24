    public class DefaultBackedCollection<T> : ICollection<T>
    {
        private readonly IList<T> defaults;
        private readonly IList<T> currents = new List<T>();
        public DefaultBackedCollection(List<T> defaultElements)
        {
            defaults = defaultElements ?? new List<T>();
        }
        public int Count => currents.Any() ? currents.Count : defaults.Count;
        public bool IsReadOnly => false;
        public void Add(T item)
        {
            currents.Add(item);
        }
        public void Clear()
        {
            currents.Clear();
        }
        public bool Contains(T item)
        {
            return currents.Any() ? currents.Contains(item) : defaults.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (currents.Any())
            {
                currents.CopyTo(array, arrayIndex);
            }
            else 
            {
                defaults.CopyTo(array, arrayIndex); 
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return currents.Any() ? currents.GetEnumerator() : defaults.GetEnumerator();
        }
        public bool Remove(T item) => currents.Remove(item);
        IEnumerator IEnumerable.GetEnumerator()
        {
            return currents.Any() ? currents.GetEnumerator() : defaults.GetEnumerator();
        }
    }
