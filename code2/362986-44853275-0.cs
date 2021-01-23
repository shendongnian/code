    if (Nullable.GetUnderlyingType(prop.PropertyType) != null) {
      tb.Columns.Add(prop.Name, prop.PropertyType.GenericTypeArguments.First().UnderlyingSystemType);
    } else {
      tb.Columns.Add(prop.Name, prop.PropertyType);
    }
