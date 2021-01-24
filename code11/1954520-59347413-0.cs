    public static class SharedState
    {
        private static readonly object _locker = new object();
        private static Decimal _value1;
        public static Decimal Value1
        {
            get { lock (_locker) return _value1; }
            set { lock (_locker) _value1 = value; }
        }
    }
