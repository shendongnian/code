    if (variable != null)
    {
        Type t = variable.GetType();
        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            // foreach...
        }
    }
