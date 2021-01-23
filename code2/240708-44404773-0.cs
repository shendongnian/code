    public class MyClassEnumerator : IEnumerator<MyClass>, IEnumerable<MyClass>
    {
        public MyClass Current { get; private set; }
        object IEnumerator.Current => Current;
        public void Reset()
        {
            ...
        }
        public bool MoveNext()
        {
            ...
        }
        
        public IEnumerator<MyClass> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public void Dispose()
        {
            ...
        }
    }
