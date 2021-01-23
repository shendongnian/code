    class SafeEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        private IEnumerable<T> _enumerable;
        public SafeEnumerable(IEnumerable<T> enumerable) { _enumerable = enumerable; }
        public IEnumerator<T> GetEnumerator()
        {
            if (_enumerable == null)
                return this;
            else
                return _enumerable.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public T Current { get { throw new InvalidOperationException(); } }
        object System.Collections.IEnumerator.Current { get { throw new InvalidOperationException(); } }
        public bool MoveNext() { return false; }
        public void Reset() { }
        public void Dispose() { }
    }
