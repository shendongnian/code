    public static T FirstOrDefault(
      this IEnumerable<T> items,
      T theDefault,
      Func<T, bool> predicate)
    {
        foreach(var i in items.Where(predicate))
          return i;
        return theDefault;
    } 
    public static R Switch<A, R>(
        A item, 
        R theDefault, 
        params (A, R)[] cases ) =>
      cases.FirstOrDefault(
        (item, theDefault),
        c => item.Equals(c.Item1)).Item2;
