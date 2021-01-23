    public static bool TryResolveDate(out DateTime date) 
    {
      date = default(DateTime);
      if (notResolvable) 
      {
        return false;
      }
    }
