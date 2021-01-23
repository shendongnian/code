        public class DisposeableEnumerable<T> : IEnumerable<T> where T : System.IDisposable
        {
            private readonly IEnumerable<T> _enumerable;
    
            public DisposeableEnumerable(IEnumerable<T> enumerable)
            {
                _enumerable = enumerable;
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return new DisposeableEnumerator<T>(_enumerable.GetEnumerator());
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
