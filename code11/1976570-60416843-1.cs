    class CircularBuffer<T>
    {
        private const int _size = 4;
        private int _index;
        private T[] _elements = new T[_size];
        public int Size => _size;
        public int Count { get; private set; }
        public bool IsFull => Count == Size;
        public T this[int i] => _elements[(_index + i)%_size];
        public T First => this[0];
        public T Last => this[_size-1];
        public void Add(T element)
        {
            _elements[_index] = element;
            _index = (_index+1) % _size;
            if (Count < _size) Count++;
        }
    }
    
