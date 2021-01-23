    static Type ReturnTypeOfClassBasedOffOfString(string className)
    {
      foreach (Assembly a in AppDomain.Current.GetAssemblies ())
      {
        foreach (Type t in a.GetTypes ())
        {
          if (t.Name == className) // Ignore namespace
            return t;
        }
      }
    
      return null;
    } 
