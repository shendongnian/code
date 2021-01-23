    public class Interval<T> where T : IComparable
    {
        private T _start;
        private T _end;
        public bool HasStart { get; private set; }
        public bool HasEnd { get; private set; }
        public Interval(T start, T end)
        {
            _start = start;
            _end = end;
            HasStart = true;
            HasEnd = true;
        }
        public Interval(T start)
        {
            _start = start;
            HasStart = true;
        }
        public Interval(T end)
        {
            _end = end;
            HasEnd = true;
        }
        public bool IsInRange(T item)
        {
            if (HasStart && item.CompareTo(_start) < 0)
            {
                return false;
            }
            if (HasEnd && item.CompareTo(_end) >= 0)
            {
                return false;
            }
            return true;
        }
    }
