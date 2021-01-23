    public sealed class Expando : DynamicObject, IDictionary<string, object>
    {
        readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _properties.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder.Name == "Add")
            {
                var del = value as Delegate;
                if (del != null && del.Method.ReturnType == typeof(void))
                {
                    var parameters = del.Method.GetParameters();
                    if (parameters.Count() == 2 && parameters.First().ParameterType == typeof(string))
                        throw new RuntimeBinderException("Method signature cannot be 'void Add(string, ?)'");
                }
            }
            _properties[binder.Name] = value;
            return true;
        }
        object IDictionary<string, object>.this[string key]
        {
            get
            {
                return _properties[key];
            }
            set
            {
                _properties[key] = value;
            }
        }
        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return _properties.Count; }
        }
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return false; }
        }
        
        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return _properties.Keys; }
        }
        ICollection<object> IDictionary<string, object>.Values
        {
            get { return _properties.Values; }
        }
        
        
        public void Add(string key, object value)
        {
            _properties.Add(key, value);
        }
        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return _properties.ContainsKey(key);
        }
        bool IDictionary<string, object>.Remove(string key)
        {
            return _properties.Remove(key);
        }
        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return _properties.TryGetValue(key, out value);
        }
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)_properties).Add(item);
        }
        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            _properties.Clear();
        }
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_properties).Contains(item);
        }
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)_properties).CopyTo(array, arrayIndex);
        }
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_properties).Remove(item);
        }
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return _properties.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_properties).GetEnumerator();
        }
    }
