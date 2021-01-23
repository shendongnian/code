    class Switch
    {
        private Dictionary<Type, Action<object>> _dict;
        private Action<object> defaultCase;
        public Switch(params KeyValuePair<Type, Action<object>>[] cases)
        {
            _dict = new Dictionary<Type, Action<object>>(cases.Length);
            foreach (var entry in cases)
                if (entry.Key == null)
                    defaultCase = entry.Value;
                else
                    _dict.Add(entry.Key, entry.Value);
        }
        public void Execute(object obj)
        {
            var type = obj.GetType();
            if (_dict.ContainsKey(type))
                _dict[type](obj);
            else if (defaultCase != null)
                defaultCase(obj);
        }
    ...
