    public class SynchronizedListsWrapper<T>
    {
        private List<T> _first;
        private List<T> _second;
        public SynchronizedListsWrapper(List<T> first, List<T> second)
        {
            _first = first;
            _second = second;
        }
        public void Add(T item)
        {
            first.Add(item);
            second.Add(item);
        }
        public void Remove(T item)
        {
            first.Remove(item);
            second.Remove(item);
        }
    }
