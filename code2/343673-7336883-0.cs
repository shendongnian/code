    public class Persistent<T>
    {
        private readonly string _sessionKey;
        private static readonly bool _valueType;
        static Persistent()
        {
            _valueType = typeof(T).IsValueType;
        }
        public Persistent(T value = default(T))
        {
            _sessionKey = Guid.NewGuid().ToString();
            SetValue(value);
        }
        private void SetValue(T value)
        {
            var item = (_valueType)
              ? new PersistentWrapper { Value = value }
              : (object)value;
            HttpContext.Current.Session[_sessionKey] = item;
        }
        private T GetValue()
        {
            object item = HttpContext.Current.Session[_sessionKey];
            if (item != null)
            {
                if (_valueType) return ((PersistentWrapper)item).Value;
                return (T)item;
            }
            return default(T);
        }
        [Serializable]
        private class PersistentWrapper
        {
            public T Value { get; set; }
        }
        public static implicit operator T(Persistent<T> value)
        {
            if (value == null) return default(T);
            return value.GetValue();
        }
        public static implicit operator Persistent<T>(T value)
        {
            return new Persistent<T>(value);
        }
    }
