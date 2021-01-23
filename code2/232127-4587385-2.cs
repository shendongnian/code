    // Skeleton code for illustration only.
    class Frame<T1, T2>
    {
        public Frame(T1 x, T2 y)
        { }
    }
    // IEnumerable (non-)implementation for initializer syntax.
    class FrameCollection : IEnumerable
    {
        List<Frame<int, int>> _frames;
        
        public FrameCollection()
        {
            _frames = new List<Frame<int, int>>();
        }
        
        // Add method to enable initialization syntax using { x, y }.
        public void Add(int x, int y)
        {
            _frames.Add(new Frame<int, int>(x, y));
        }
        
        public Frame<int, int>[] ToArray()
        {
            return _frames.ToArray();
        }
        
        // This method doesn't technically need to do anything.
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException();
        }
    }
