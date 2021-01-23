    public static void IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
      if(collection == null)
        return true;
    
      return collection.Any();
    }
