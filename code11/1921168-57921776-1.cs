    public List(IEnumerable<T> collection)
    {
      if (collection == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
      if (count == 0)
      {
        this._items = List<T>._emptyArray;
      }
      else
      {
        this._items = List<T>._emptyArray;
        foreach (T obj in collection)
          this.Add(obj);
        this._size = count;
      }
    }
