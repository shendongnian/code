    public static bool CompareExcept<T>(T first, T second, params string[] excludeNames)
    {
      foreach (PropertyInfo pi in typeof(T).GetProperties())
      {
        if (excludeNames.Contains(pi.Name)) // case sensitive
          continue;
        object propFirst = pi.GetGetMethod().Invoke(first, null);
        object propSecond = pi.GetGetMethod().Invoke(second, null);
        if (propFirst == null)
        {
          if (propSecond != null)
            return false;
        }
        else
        {
          if (!propFirst.Equals(propSecond))
            return false;
        }
      }
      return true;
    }
