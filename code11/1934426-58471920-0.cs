    public object Foo(object original)
    {
      if ( original is System.Collections.IEnumerable )
      {
        List<object> copy = new List<object>();
        foreach ( var item in original as System.Collections.IEnumerable )
          copy.Add(item);
        return copy;
      }
      else
        return null;
    }
