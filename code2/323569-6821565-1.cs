    public class EmptyLookup<T, K> : ILookup<T, K> {
            private static readonly ILookup<T, K> _instance = new EmptyLookup<T, K>();
            public static ILookup<T, K> Instance
            {
                get
                {
                    return _instance;
                }
            }
            private EmptyLookup()
	        {
	        }
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
                get { throw new KeyNotFoundException (); }
            }
            public IEnumerator<IGrouping<T, K>> GetEnumerator()
            {
                return Enumerable.Empty<IGrouping<T, K>>().GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
