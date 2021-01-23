    public T this[int idx]
    {
      get
      {
        return _inner[idx];
      }
    }
    T IList<T>.this[int index]
    {
      get { return this[index]; }
      set { throw new NotSupportedException("Collection is read-only."); }
    }
    public int Count
    {
      get
      {
        return _inner.Count;
      }
    }
    void ICollection<T>.Add(T item)
    {
      throw new NotSupportedException("Read only list.");
    }
    bool ICollection<T>.IsReadOnly
      {
      get
      {
        return false;
      }
    }
