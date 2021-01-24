    public static bool TryGetValue<T,T2>(T instance, string name, out string value)
    {
       ...
    
       switch (member.MemberType)
       {
          case MemberTypes.Field:
             value = (T2)(member as FieldInfo)?.GetValue(instance);
          ...
    }
