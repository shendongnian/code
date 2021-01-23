    public MyObject(IEnumerable<T>  items)
    {
        _innerItems = new Dictionary<int, T>();
        foreach (var item in items)
        {
            _innerItems.Add(item.Key, item);
        }
    }
