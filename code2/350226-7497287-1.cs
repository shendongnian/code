    public static class CoalesceExtensions
    {
        class EmptyEnumerable<T> : ICollection<T>, IEnumerable<T>, IEnumerator<T>
        {
            public static readonly EmptyEnumerable<T> Default = new EmptyEnumerable<T>();
            private EmptyEnumerable() { }
            public IEnumerator<T> GetEnumerator() { return this; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this; }
            public T Current { get { throw new InvalidOperationException(); } }
            object System.Collections.IEnumerator.Current { get { throw new InvalidOperationException(); } }
            public int Count { get { return 0; } }
            public bool IsReadOnly { get { return true; } }
            public bool MoveNext() { return false; }
            public void Reset() { }
            public void Dispose() { }
            public void Add(T item) { throw new InvalidOperationException(); }
            public void Clear() { throw new InvalidOperationException(); }
            public bool Remove(T item) { throw new InvalidOperationException(); }
            public bool Contains(T item) { return false; }
            public void CopyTo(T[] array, int arrayIndex) { }
        }
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> values)
        {
            return values ?? EmptyEnumerable<T>.Default;
        }
    }
