    public static bool In<T>(this T item, params T [] set)
    {
      return set.Contains(item);
    }
    
    
    bool result = x.In(MyEnum.A, MyEnum.B, MyEnum.C);
