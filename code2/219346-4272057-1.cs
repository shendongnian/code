    public static string Recurse(string initialPattern, ObjectDict dict) {
      Func<string, string> inner = null;
      inner = pattern => {
        // Logic which uses calls to inner for recursion.  Has access to dict
        // because it's a lambda.  For example
        if (dict.SomeOperation()) { 
          return inner(someOtherPattern);
        }
        return aValue;
      };
      return inner(initialPattern);
    }
