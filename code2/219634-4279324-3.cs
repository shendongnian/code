    public struct WriteOnce<T>
    {
        private T _value;
        private bool _hasValue;
        public bool HasValue { get { return _hasValue; } }
        public T Value
        {
            get { return _value; }
            set
            {
                if (HasValue) throw new InvalidOperationException();
                _value = value;
                _hasValue = true;
            }
        }
        public static implicit operator T(WriteOnce<T> x)
        {
            return x.Value;
        }
        public WriteOnce(T val)
        {
            _value = val;
            _hasValue = true;
        }
    }
