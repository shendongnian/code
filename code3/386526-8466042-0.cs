    class DummyWrapper : IDummy
    {
        private readonly DynamicObject _wrapped;
        public DummyWrapper(DynamicObject wrapped)
        {
            _wrapped = wrapped;
        }
        string First
        {
            get { return _wrapped.First; }
            set { _wrapped.First = value; }
        }
        string Second
        {
            get { return _wrapped.Second; }
            set { _wrapped.Second = value; }
        }
        string Third
        {
            get { return _wrapped.Third; }
            set { _wrapped.Third = value; }
        }
        string Fourth
        {
            get { return _wrapped.Fourth; }
            set { _wrapped.Fourth = value; }
        }
    }
