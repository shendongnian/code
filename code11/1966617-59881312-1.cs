    private static string LongName<T>(long value) where T : Enum {
      unchecked {
        return string.Join(", ", Enum
          .GetNames(typeof(T))
          .Where(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)) == value)
          .OrderBy(name => name));
      }
    }
    private static string[] LongNames<T>() where T : Enum {
      unchecked {
        return Enum
          .GetNames(typeof(T))
          .OrderBy(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)))
          .ThenBy(name => name)
          .ToArray();
      }
    }
    ...
   
    // Single Value
    Console.Write(LongName<MyEnum>(1));
    // All Values
    Console.Write(string.Join(", ", LongNames<MyEnum>())); 
