    private static string LongName<T>(long value) where T : Enum {
      unchecked {
        return string.Join(" or ", Enum
          .GetNames(typeof(T))
          .Where(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)) == value)
          .OrderBy(name => name));
      }
    }
    private static string LongAttributeName<T>(long value) where T : Enum {
      unchecked {
        return string.Join(" or ", Enum
          .GetNames(typeof(T))
          .Where(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)) == value)
          .Select(name => typeof(T)
             .GetMember(name)
             .FirstOrDefault(mi => mi.DeclaringType == typeof(T)))
          .SelectMany(mi => mi.GetCustomAttributes<CategoryEnumAttribute>(false))
          .Select(attr => attr.Description) //TODO: Put the right property here
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
    private static string[] LongNamesCombined<T>() where T : Enum {
      unchecked {
        return Enum
          .GetNames(typeof(T))
          .GroupBy(name => Convert.ToInt64(Enum.Parse(typeof(MyEnum), name)))
          .OrderBy(group => group.Key)
          .Select(group => string.Join(" or ", group.OrderBy(name => name)))
          .ToArray();
      }
    }
