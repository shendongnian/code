    public static R Switch<A, R>(
      A item, 
      R theDefault, 
      params (A, R)[] cases )
    {
        foreach(var c in cases) 
            if (item.Equals(c.Item1))
                return c.Item2;
        return theDefault;
    }
