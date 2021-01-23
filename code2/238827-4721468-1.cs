    public void Add(T1 key, T3 value)
    {
        T2 list;
        if (!_underlyingDict.TryGetValue(key, out list))
        {
            list = new T2();
            _underlyingDict[key] = list;
        }
        list.Add(value);
    }
