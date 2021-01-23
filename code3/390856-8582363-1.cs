    public static void IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
      if(enumerable == null)
        return true;
    
      return !enumerable.Any();
    }
