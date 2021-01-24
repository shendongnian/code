    public static T GetValue<T>(object instance , MemberInfo member)
    {
       switch (member.MemberType)
       {
          case MemberTypes.Field: return (T)(member as FieldInfo)?.GetValue(instance);
          case MemberTypes.Method: return (T)(member as MethodInfo)?.Invoke(instance, null);
          case MemberTypes.Property: return (T)(member as PropertyInfo)?.GetValue(instance);
          default:return default;
       }
    }
     
    public static bool TryGetValue<T>(Assembly asm, string className, string name, out T value)
    {
       value = default;    
       var type = asm.GetType(className);    
       var instance = Activator.CreateInstance(type);
    
       try
       {
          var member = type.GetMember(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                           .FirstOrDefault();
    
          if (instance == null || member == null) return false;
    
          value = GetValue<T>(instance, member);
       }
       finally
       {
          (instance as IDisposable)?.Dispose();
       }
    
       return true;   
    }
