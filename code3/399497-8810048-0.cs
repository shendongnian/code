    public class GroupedDictionary<T> : IDictionary<T,IList<T>>
    {
        private Dictionary<T, int> _keys;
        private Dictionary<int, IList<T>> _valueGroups;
    
        public GroupedDictionary()
        {
            _keys = new Dictionary<T, int>();
            _valueGroups = new Dictionary<int, IList<T>>();
        }
    
        public void Add(KeyValuePair<T, IList<T>> item)
        {
            Add(item.Key, item.Value);
        }
    
        public void Add(T key, IList<T> value)
        {
            // look if some of the values already exist
            int existingGroupKey = -1;
            foreach (T v in value)
            {
                if (_keys.Keys.Contains(v))
                {
                    existingGroupKey = _keys[v];
                    break;
                }
            }
            if (existingGroupKey == -1)
            {
                // new group
                int newGroupKey = _valueGroups.Count;
                _valueGroups.Add(newGroupKey, new List<T>(value));
                _valueGroups[newGroupKey].Add(key);
                foreach (T v in value)
                {
                    _keys.Add(v, newGroupKey);
                }
                _keys.Add(key, newGroupKey);
            }
            else
            {
                // existing group
                _valueGroups[existingGroupKey].Add(key);
                // add items that are new
                foreach (T v in value)
                {
                    if(!_valueGroups[existingGroupKey].Contains(v))
                    {
                        _valueGroups[existingGroupKey].Add(v);
                    }
                }
                // add new keys
                _keys.Add(key, existingGroupKey);
                foreach (T v in value)
                {
                    if (!_keys.Keys.Contains(v))
                    {
                        _keys.Add(v, existingGroupKey);
                    }
                }
            }
        }
        public IList<T> this[T key]
        {
            get { return _valueGroups[_keys[key]]; }
            set { throw new NotImplementedException(); }
        }
    }
