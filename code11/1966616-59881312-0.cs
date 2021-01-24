    private static string LongName<T>(long value) where T : Enum {
      unchecked {
        return string.Join(", ", Enum
          .GetNames(typeof(T))
          .Where(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)) == value)
          .OrderBy(name => name));
      }
    }
    ...
   
    Console.Write(LongName<MyEnum>(1));
