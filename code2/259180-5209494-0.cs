    class NameValueCollection<T>
    {
        Dictionary<string, List<T>> _dict = new Dictionary<string, List<T>>();
    
        public void Add(string name, T value)
        {
            List<T> list;
            if (!_dict.TryGetValue(name, out list))
            {
                _dict[name] = list = new List<T>();
            }
    
            list.Add(value);
        }
        // etc.
    }
