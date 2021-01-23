    public static T ToNonNull<T>(this T input) where T : class, new()
    {
      if (input != null)
      {
        return input;
      }
      return new T();
    }
