    IEnumerator<int> GetEnumerator()
    {
       ...
    }
    
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return GetEnumerator();//Forward to strongly typed version
    }
