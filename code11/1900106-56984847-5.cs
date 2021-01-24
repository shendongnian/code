      var fields = item
        .GetType()
        .GetFields(BindingFlags.Public | BindingFlags.Instance)
        .Select(fi => new {
          name = fi.Name,
          value = fi.GetValue(fi.IsStatic ? null : item),
          type = fi.FieldType,
          kind = "field",
        });
