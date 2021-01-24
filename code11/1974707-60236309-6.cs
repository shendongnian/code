    public static bool TryGetValue<T>(Assembly asm, string className, string name, out T value)
    {
       value = default;
    
       var type = asm.GetType(className);
    
       var instance = Activator.CreateInstance(type);
    
       var member = type.GetMember(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        .FirstOrDefault();
    
       if (instance == null || member == null)return false;
    
       switch (member.MemberType)
       {
          case MemberTypes.Field:
             value = (T)(member as FieldInfo)?.GetValue(instance);
             break;
          case MemberTypes.Method:
             value = (T)(member as MethodInfo)?.Invoke(instance, null);
             break;
          case MemberTypes.Property:
             value = (T)(member as PropertyInfo)?.GetValue(instance);
             break;
          default:
             return false;
       }
    
       (instance as IDisposable)?.Dispose();
    
       return true;
    
    }
