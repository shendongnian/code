    public static IEnumerable<KeyValuePair<K, T>> SortByMember<K, T>(this Dictionary<K, T> data, string memberName)
    {
      Type type = typeof(T);
      MemberInfo info = type.GetProperty(memberName) ?? type.GetField(memberName) as MemberInfo;
      if (info == null) return data;
      Func<KeyValuePair<K, T>, object> getter = null;
      if (info is PropertyInfo pi)
        getter = kvp => pi.GetValue(kvp.Value);
      else if (info is FieldInfo fi)
        getter = kvp => fi.GetValue(kvp.Value);
      return data.OrderBy(getter);
    }
