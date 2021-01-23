    public class SynchronizedListsWrapper
    {
        private readonly ArrayList _first;
        private readonly ArrayList _second;
        public SynchronizedListsWrapper(ArrayList first, ArrayList second)
        {
            _first = first;
            _second = second;
        }
        public void Add(object item)
        {
            first.Add(item);
            second.Add(item);
        }
        public void Remove(object item)
        {
            first.Remove(item);
            second.Remove(item);
        }
    }
