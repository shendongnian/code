    public IEnumerator<T> GetEnumerator()
    {
      //some code that returns an appropriate object.
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();//return the result of the other call.
    }
