    public abstract class Shared
    {
        private readonly static Dictionary<Guid, object> _Variables
            = new Dictionary<Guid, object>();
        
        protected void SetValue<T>(Guid key, T value)
        {
            lock (_Variables)
                _Variables[key] = value;
        }
    
        protected T GetValue<T>(Guid key)
        {
            object temp;
            lock (_Variables)
                if (!_Variables.TryGetValue(key, out temp))
                    return default;
                    
            return (T)temp;
        }
    }
    
    public class Shared<T> : Shared
    {
        private readonly Guid _Key;
        
        public Shared(Guid key)
        {
            _Key = key;
        }
    
        public T Value
        {
            get => GetValue<T>(_Key);
            set => SetValue<T>(_Key, value);
        }
    }
