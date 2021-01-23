    private static bool IsPublicType(Type t)
    {
    
      if ((!t.IsPublic && !t.IsNestedPublic) || t.IsGenericType)
      {
        return false;
      }
    
      int lastIndex = t.FullName.LastIndexOf('+');
    
      if (lastIndex > 0)
      {
        var containgTypeName = t.FullName.Substring(0, lastIndex);
    
        var containingType = Type.GetType(containgTypeName + "," + t.Assembly);
    
        if (containingType != null)
        {
          return containingType.IsPublic;
        }
    
        return false;
      }
      else
      {
        return t.IsPublic;
      }
    }
