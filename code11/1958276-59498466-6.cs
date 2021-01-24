      Object objectToInspect = this;
      HashSet<Type> typleTypes = new HashSet<Type>() {
        typeof(Tuple<>),
        typeof(Tuple<,>),
        typeof(Tuple<,,>),
        typeof(Tuple<,,,>),
        typeof(Tuple<,,,,>),
        typeof(Tuple<,,,,,>),
        typeof(Tuple<,,,,,,>),
        typeof(Tuple<,,,,,,,>),
      };
      var fieldsWithTuples = objectToInspect
        .GetType()
        .GetFields(BindingFlags.NonPublic |
                   BindingFlags.Instance |
                   BindingFlags.Public |
                   BindingFlags.Static |
                   BindingFlags.FlattenHierarchy)
        .Where(field => field.FieldType.IsGenericType)
        .Where(field => typleTypes.Contains(field.FieldType.GetGenericTypeDefinition()))
        .Select(field => new {
          name  = field.Name,
          value = field.GetValue(field.IsStatic
                     ? null                     // we should provide null for static
                     : objectToInspect)
        })
        .Where(item => item.value != null);
