    bool IsCollectionOfValueTypes(Object argValue)
    {
      Type t = argValue.GetType();
      if(t.IsArray)
      {
        return t.GetElementType().IsValueType;
      }
      else
      {
        if (t.IsGeneric)
        {
          Types[] gt = t.GetGenericArguments();
           return (gt.Length == 1) && gt[0].IsValueType;
        }
      }
      return false;
    }
