    public enum SettableLazyThreadSafetyMode // a copy of LazyThreadSafetyMode - just use that if you only care for .NET4.0
    {
        None,
        PublicationOnly,
        ExecutionAndPublication
    }
    public class SettableLazy<T>
    {
        private T _value;
        private volatile bool _isCreated;
        private readonly Func<T> _factory;
        private readonly object _lock;
        private readonly SettableLazyThreadSafetyMode _mode;
        public SettableLazy(T value, Func<T> factory, SettableLazyThreadSafetyMode mode)
        {
            if(null == factory)
                throw new ArgumentNullException("factory");
            if(!Enum.IsDefined(typeof(SettableLazyThreadSafetyMode), mode))
               throw new ArgumentOutOfRangeException("mode");
            _lock = (_mode = mode) == SettableLazyThreadSafetyMode.None ? null : new object();
            _value = value;
            _factory = factory;
            _isCreated = true;
        }
        public SettableLazy(Func<T> factory, SettableLazyThreadSafetyMode mode)
            :this(default(T), factory, mode)
        {
            _isCreated = false;
        }
        public SettableLazy(T value, SettableLazyThreadSafetyMode mode)
            :this(value, () => Activator.CreateInstance<T>(), mode){}
        public T Value
        {
            get
            {
                if(!_isCreated)
                    switch(_mode)
                    {
                        case SettableLazyThreadSafetyMode.None:
                            _value = _factory.Invoke();
                            _isCreated = true;
                            break;
                        case SettableLazyThreadSafetyMode.PublicationOnly:
                            T value = _factory.Invoke();
                            if(!_isCreated)
                                lock(_lock)
                                    if(!_isCreated)
                                    {
                                        _value = value;
                                        Thread.MemoryBarrier(); // ensure all writes involved in setting _value are flushed.
                                        _isCreated = true;
                                    }
                            break;
                        case SettableLazyThreadSafetyMode.ExecutionAndPublication:
                            lock(_lock)
                            {
                                if(!_isCreated)
                                {
                                    _value = _factory.Invoke();
                                    Thread.MemoryBarrier();
                                    _isCreated = true;
                                }
                            }
                            break;
                    }
                return _value;
            }
            set
            {
                if(_mode == SettableLazyThreadSafetyMode.None)
                {
                    _value = value;
                    _isCreated = true;
                }
                else
                    lock(_lock)
                    {
                        _value = value;
                        Thread.MemoryBarrier();
                        _isCreated = true;
                    }
            }
        }
        public void Reset()
        {
            if(_mode == SettableLazyThreadSafetyMode.None)
            {
                _value = default(T); // not strictly needed, but has impact if T is, or contains, large reference type and we really want GC to collect.
                _isCreated = false;
            }
            else
                lock(_lock) //likewise, we could skip all this and just do _isCreated = false, but memory pressure could be high in some cases
                {
                    _value = default(T);
                    Thread.MemoryBarrier();
                    _isCreated = false;
                }
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public static implicit operator T(SettableLazy<T> lazy)
        {
            return lazy.Value;
        }
        public static implicit operator SettableLazy<T>(T value)
        {
            return new SettableLazy<T>(value, SettableLazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
