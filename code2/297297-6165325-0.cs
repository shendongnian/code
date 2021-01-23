    public static bool IfOr(this bool result, params bool[] tests)
    {
      foreach (bool test in tests)
        if (!test)
          return !result;
      return result;
    }
