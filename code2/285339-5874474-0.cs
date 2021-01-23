    public class ThreadSafeList<T> : IList<T>
    {
        protected List<T> _interalList = new List<T>();
        // Other Elements of IList implementation
        public IEnumerator<T> GetEnumerator()
        {
            return Clone().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Clone().GetEnumerator();
        }
        protected static object _lock = new object();
        public List<T> Clone()
        {
            List<T> newList = new List<T>();
            lock (_lock)
            {
                _interalList.ForEach(x => newList.Add(x));
            }
            return newList;
        }
    }
