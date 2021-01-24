    Object[] values = typeof(SpYtMessageConstants)
      .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
      .Where(f => f.IsLiteral && !f.IsInitOnly)
      .Select(f => f.GetValue(null))
      .ToArray();
