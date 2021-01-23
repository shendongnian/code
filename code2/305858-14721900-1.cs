    private static ClientTypeUtil.KeyKind IsKeyProperty(PropertyInfo propertyInfo, DataServiceKeyAttribute dataServiceKeyAttribute)
    {
      string name1 = propertyInfo.Name;
      ClientTypeUtil.KeyKind keyKind = ClientTypeUtil.KeyKind.NotKey;
      if (dataServiceKeyAttribute != null && dataServiceKeyAttribute.KeyNames.Contains(name1))
        keyKind = ClientTypeUtil.KeyKind.AttributedKey;
      else if (name1.EndsWith("ID", StringComparison.Ordinal))
      {
        string name2 = propertyInfo.DeclaringType.Name;
        if (name1.Length == name2.Length + 2 && name1.StartsWith(name2, StringComparison.Ordinal))
          keyKind = ClientTypeUtil.KeyKind.TypeNameId;
        else if (2 == name1.Length)
          keyKind = ClientTypeUtil.KeyKind.Id;
      }
      return keyKind;
    }
