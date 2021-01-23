    public class MySpecialCollection<T> : IEnumerable<T>
    { 
        public IEnumerator<T> GetEnumerator()
        {
            return new MySpecialEnumerator(...);
        }
    
        private class MySpecialEnumerator : IEnumerator<T>
        {
            public bool MoveNext() { ... }
            public T Current
            { 
                get { return ...; }
            }
            // etc...
        } 
    }
