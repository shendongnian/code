    public T this[int idx]
    {
      get
      {
        return _inner[idx];
      }
      set
      {
        throw new NotSupportedException("Read only list.");
      }
    }
    public int Count
    {
      get
      {
        return _inner.Count;
      }
    }
    public void Add(T item)
    {
      throw new NotSupportedException("Read only list.");
    }
    public bool IsReadOnly
      {
      get
      {
        return false;
      }
    }
