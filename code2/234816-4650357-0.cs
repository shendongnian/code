    class A : IDisposable
    {
        static Dictionary<Type, int> _typeCounts = new Dictionary<Type, int>();
        private bool _disposed = false;
        public static int GetCount<T>() where T:A
        {
            if (!_typeCounts.ContainsKey(typeof(T))) return 0;
            return _typeCounts[typeof(T)];
        }
        public A()
        {
            Increment();
        }
        private void Increment()
        {
            var type = this.GetType();
            if (!_typeCounts.ContainsKey(type)) _typeCounts[type] = 0;
            _typeCounts[type]++;
        }
        private void Decrement()
        {
            var type = this.GetType();
            _typeCounts[type]--;            
        }
        ~A()
        {
            if (!_disposed) Decrement();
        }
        public void Dispose()
        {
            _disposed = true;
            Decrement();
        }
    }
    class B : A
    {
        
    }
