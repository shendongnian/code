      public static string ReadConstant<T>(string name = null) {
        if (string.IsNullOrEmpty(name))
          name = "Name";
        if (s_Dictionary.TryGetValue(Tuple.Create(typeof(T), name), out string value))
          return value;
        else
          return null; // Or throw exception
      }
