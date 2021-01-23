        public void Execute(object obj)
        {
            Execute(obj, (IEnumerable<KeyValuePair<Type, Action<object>>>)_dict);
        }
        public static void Execute(object obj, params KeyValuePair<Type, Action<object>>[] cases)
        {
            Execute(obj, (IEnumerable<KeyValuePair<Type, Action<object>>>)cases);
        }
        public static void Execute(object obj, IEnumerable<KeyValuePair<Type, Action<object>>> cases)
        {
            var type = obj.GetType();
            Action<object> defaultEntry = null;
            foreach (var entry in cases)
            {
                if (entry.Key == typeof(DefaultClass))
                    defaultEntry = entry.Value;
                if (type.IsAssignableFrom(entry.Key))
                {
                    entry.Value(obj);
                    return;
                }
            }
            if (defaultEntry != null)
                defaultEntry(obj);
        }
