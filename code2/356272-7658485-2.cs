    class T : IEnumerable<int>
    {
        public T() { }
        public IEnumerator<int> GetEnumerator() { return new TEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        private class TEnumerator : IEnumerator<int>
        {
            private int position = -1;
            public int Current { get { return position; } }
            object IEnumerator.Current { get { return Current; } }
            void IDisposable.Dispose() {}
            public bool MoveNext()
            {
                position++;
                return (position < 5);
            }
            public void Reset() { position = -1; }
        } 
    }
