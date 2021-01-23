    public static IDictionary<TKey, TValue> New<TKey, TValue>(out IDictionary<TKey, TValue> item)
    {
         item = new Dictionary<TKey, TValue>();
    
         return item;
    }
    
    public static IList<T> New<T>(out IList<T> item)
    {
         item = new List<T>();
    
         return item;
    }
