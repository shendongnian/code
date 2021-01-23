public static T EnumSetAll<T>() where T : struct, Enum
  {
    string str = string.Join(", ", Enum.GetNames(typeof(T)));
    if (Enum.TryParse<T>(str, out var e))
      return e;
    return default;
  }
