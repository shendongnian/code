public object Parse(object value, PropertyInfo property, FieldProviderOptions fieldProviderOptions)
    {
      if (property.PropertyAlias.Equals("aliases", StringComparison.CurrentCultureIgnoreCase))
      {
        value = string.Join("\r\n", value.AsString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()));
      }
      return value;
    }
