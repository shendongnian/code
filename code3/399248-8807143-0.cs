    public static IsSubetOf (this IEnumerable coll1, IEnumerable coll2)
    {
      foreach (var elem in coll1)
      {
        if (!coll2.Contains (elem))
        {
          return false;
        }
      }
      
      return true;
    }
