    if (variable != null)
    {
        if (variable.GetType().GetInterfaces().Any(
                i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
        {
            // foreach...
        }
    }
