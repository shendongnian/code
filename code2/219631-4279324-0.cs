    public struct WriteOnce<T>
    {
        private T? _value;
        public T Value
        {
            get { return _value; }
            set
            {
                if (_value.HasValue) throw new InvalidOperationException();
                _value = value;
            }
        }
    }
