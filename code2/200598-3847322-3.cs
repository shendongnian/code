    struct Range : IEnumerable<int>
    {
        readonly int _start;
        readonly int _count;
        public Range(int start, int count)
        {
            _start = start;
            _count = count;
        }
        public int Start
        {
            get { return _start; }
        }
        public int Count
        {
            get { return _count; }
        }
        public int End
        {
            get { return _start + _count - 1; }
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _count; ++i)
            {
                yield return _start + i;
            }
        }
        // Heck, why not?
        public static Range operator +(Range x, int y)
        {
            return new Range(x.Start, x.Count + y);
        }
        
        // skipping the explicit IEnumerable.GetEnumerator implementation
    }
