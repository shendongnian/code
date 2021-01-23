    //Generic.  All items in the set and the candidate must be the same type.
    public static bool In<T>(this T item, params T [] set)
    {
      return set.Contains(item);
    }
       
    bool result = x.In(MyEnum.A, MyEnum.B, MyEnum.C);
    //Non-generic and non-typesafe.  Anything goes.  Use with care!
    public static bool In(this object item, params object [] set)
    {
      return set.Contains(item);
    }
    
    
    bool result = x.In(MyEnum.A, MyEnum.B, 42);
    //int-specific.  
    public static bool In(this int item, params int [] set)
    {
      return set.Contains(item);
    }
    
    
    bool result = x.In((int)MyEnum.A, (int)MyEnum.B, 42);
