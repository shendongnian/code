    [ThreadStatic]
    private static Dictionary<T,object> cache;
    public object BoxIt<T>(T value)
      where T:struct
    {
      if(cache==null)
        cache=new Dictionary<T,object>();
      object result;
      if(!cache.TryGetValue(T,result))
      {
        result=(object)T;
        cache[value]=result;
      }
      return result;
    }
