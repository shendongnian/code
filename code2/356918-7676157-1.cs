    public delegate int IdGetter<in T>(T holder);
    public delegate T IdSetter<in T>(T holder, int newId);
    private static void RewriteIListIds<T>(
      IList<T> pre, 
      IList<T> post
      IdGetter idGetter,
      IdSetter idSetter)
    {
      // To get the id
      int id = idGetter(someObject);
    
      // To set id
      someObject = idSetter(someObject, newId);
    
