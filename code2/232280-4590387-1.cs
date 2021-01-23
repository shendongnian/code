    if (variable != null)
    {
        Type t = variable.GetType();
        if (t.GetInterfaces().Any(i =>
            i.IsGenericType && i.GetGenericTypeDefinition == typeof(IEnumerable<>)))
        {
            // foreach...
        }
    }
