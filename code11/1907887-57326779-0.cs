    if (prop.PropertyType.IsGenericType &&
        typeof(ICollection<>).IsAssignableFrom(prop.PropertyType.GetGenericTypeDefinition()))
    {
        foreach (var child in (prop.GetValue(entity) as IEnumerable)) //Cast it here
        {
            MarkDeleted(child);
        }
    }
