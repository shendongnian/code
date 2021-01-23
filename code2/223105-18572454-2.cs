    /// <summary>
    /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="T:System.Collections.Generic.List`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <paramref name="T"/>.
    /// </returns>
    /// <param name="match">The <see cref="T:System.Predicate`1"/> delegate that defines the conditions of the element to search for.</param><exception cref="T:System.ArgumentNullException"><paramref name="match"/> is null.</exception>
    [__DynamicallyInvokable]
    public T Find(Predicate<T> match)
    {
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      for (int index = 0; index < this._size; ++index)
      {
        if (match(this._items[index]))
          return this._items[index];
      }
      return default (T);
    }
