    // untested
    class OverFlowList<T>
    {
        T[] _data;
        int _next;
    
        public OferflowList(int limit)
        {
            _data = new T[limit];
        }
    
    
        void Add(T item)
        {
            _data[_next] = item;
            _next = (_next + 1) % _data.Length;
        }
    
    }
