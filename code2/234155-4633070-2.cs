    class Switch
    {
        private class DefaultClass { }
        ....
        public void Execute(object obj)
        {
            var type = obj.GetType();
            Action<object> value;
            // first look for actual type
            if (_dict.TryGetValue(type, out value) ||
            // look for default
                _dict.TryGetValue(typeof(DefaultClass), out value))
                value(obj);
        }
        public static void Execute(object obj, params KeyValuePair<Type, Action<object>>[] cases)
        {
            var type = obj.GetType();
          
            foreach (var entry in cases)
            {
                if (entry.Key == typeof(DefaultClass) || type.IsAssignableFrom(entry.Key))
                {
                    entry.Value(obj);
                    break;
                }
            }
        }
        ...
        public static KeyValuePair<Type, Action<object>> Default(Action action)
        {
            return new KeyValuePair<Type, Action<object>>(new DefaultClass(), x => action());
        }
    }
