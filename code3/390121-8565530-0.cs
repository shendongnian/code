      public static MemberInfo GetPropertyOrField(this Type type, string propertyOrField)
      {
          MemberInfo member = type.GetProperty(propertyOrField, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
          if (member == null)
              member = type.GetField(propertyOrField, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
  
          Debug.Assert(member != null);
          return member;
      }
