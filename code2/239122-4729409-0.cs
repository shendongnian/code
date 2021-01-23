    class LocklessQueue<T>
    {
        class Item
        {
            public Item Next;
            bool _valid;
            T _value;
            public Item(bool valid, T value)
            {
                _valid = valid;
                _value = value;
                Next = null;
            }
            public bool IsValid { get { return _valid; } }
            public T TakeValue()
            {
                T value = _value;
                _valid = false;
                _value = default(T);
                return value;
            }
        }
        Item _first;
        Item _last;
        public LocklessQueue()
        {
            _first = _last = new Item(false, default(T));
        }
        public bool IsEmpty
        { 
            get
            {
                while (!_first.IsValid && _first.Next != null)
                    _first = _first.Next;
                return false == _first.IsValid;
            }
        }
        public void Enqueue(T value)
        {
            Item i = new Item(true, value);
            _last.Next = i;
            _last = i;
        }
        public T Dequeue()
        {
            while (!_first.IsValid && _first.Next != null)
                _first = _first.Next;
            if (IsEmpty)
                throw new InvalidOperationException();//queue is empty
            return _first.TakeValue();
        }
    }
