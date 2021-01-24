    public static bool TryGetValue<T>(T instance, string name, out string value)
    {
       value = default;
    
       var member = typeof(T).GetMember(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                             .FirstOrDefault();
    
       if (member == null)return false;
    
       switch (member.MemberType)
       {
          case MemberTypes.Field:
             value = (member as FieldInfo)?.GetValue(instance).ToString();
             break;
          case MemberTypes.Method:
             value = (member as MethodInfo)?.Invoke(instance, null).ToString();
             break;
          case MemberTypes.Property:
             value = (member as PropertyInfo)?.GetValue(instance).ToString();
             break;
          default:
             return false;
       }
    
       return true;
    
    }
