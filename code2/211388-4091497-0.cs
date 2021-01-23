    public class ProtectedEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> collection;
        public ProtectedEnumerable(IEnumerable<T> collection)
        {
            this.collection = collection;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
