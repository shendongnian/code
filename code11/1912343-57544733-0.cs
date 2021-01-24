    public class Lazy<T>
    {
        private readonly Func<T> _creator;
        private T _cachedValue;
        public Lazy(Func<T> creator) => _creator = creator;
        public bool IsValueCreated { get; private set; }
        public T Value
        {
            get
            {
                if (!IsValueCreated)
                {
                    _cachedValue = _creator();
                    IsValueCreated = true;
                }
                return _cachedValue;
            }
        }
    }
