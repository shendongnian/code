    public TValue this[TKey key]
        {
            get
            {
                if (!_hashTable.ContainsKey(key))
                {
                    throw new KeyNotFoundException();
                }
                return (TValue)_hashTable[key];
            }
            set
            {
                _hashTable.SetWeak(key, value);
            }
        }
