    public class MyClass<T,U> : IEnumerable<T>
    {
        public void Add(T t, U u)
        {
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
