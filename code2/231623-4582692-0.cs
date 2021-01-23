    public class CoolClassName
    {
        private Dictionary<Type, object> _items = new Dictionary<Type, object>();
     
    
        public T Get<T>()
        {
            T value;
            if (_items.TryGetValue(typeof(T), out value)
               return (T)value;
            return null;
        }
    
        public void Set<T>(T value)
        {
            _items[typeof(T)] = value;
        }
    }
