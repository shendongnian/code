    using System.Linq;
    public sealed class EmptyLookup<T, K> : ILookup<T, K> 
    {
            public static readonly EmptyLookup<T, K> Instance 
                = new EmptyLookup<T, K>();
            private EmptyLookup() { }
            public bool Contains(T key)
            {
                return false;
            }
            public int Count
            {
                get { return 0; }
            }
            public IEnumerable<K> this[T key]
            {
                get { return Enumerable.Empty<K>(); }
            }
            public IEnumerator<IGrouping<T, K>> GetEnumerator()
            {
                return Enumerable.Empty<IGrouping<K, V>>().GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
