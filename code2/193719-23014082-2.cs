        public class DisposeableEnumerator<T> : IEnumerator<T> where T : System.IDisposable
        {
            readonly List<T> toBeDisposed = new List<T>();
    
            private readonly IEnumerator<T> _enumerator;
    
            public DisposeableEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
            }
    
            public void Dispose()
            {
                // dispose the remaining disposeables
                while (_enumerator.MoveNext()) {
                    T current = _enumerator.Current;
                    current.Dispose();
                }
    
                // dispose the provided disposeables
                foreach (T disposeable in toBeDisposed) {
                    disposeable.Dispose();
                }
    
                // dispose the internal enumerator
                _enumerator.Dispose();
            }
    
            public bool MoveNext()
            {
                bool result = _enumerator.MoveNext();
    
                if (result) {
                    toBeDisposed.Add(_enumerator.Current);
                }
    
                return result;
            }
    
            public void Reset()
            {
                _enumerator.Reset();
            }
    
            public T Current
            {
                get
                {
                    return _enumerator.Current;
                }
            }
    
            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
