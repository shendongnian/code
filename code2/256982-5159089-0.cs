    public class ThrowingHashSet<T> : ICollection<T>
    {
        private HashSet<T> innerHash = new HashSet<T>();
    
        public void Add(T item)
        {
            if (!innerHash.Add(item))
                throw new ValueExistingException();
        }
    
        public void Clear()
        {
            innerHash.Clear();
        }
    
        public bool Contains(T item)
        {
            return innerHash.Contains(item);
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            innerHash.CopyTo(array, arrayIndex);
        }
    
        public int Count
        {
            get { return innerHash.Count; }
        }
    
        public bool IsReadOnly
        {
            get { return false; }
        }
    
        public bool Remove(T item)
        {
            return innerHash.Remove(item);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return innerHash.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
