    foreach(var entry in types)
    {
        if (node != null && entry.Key.IsAssignableFrom(node.GetType()))
        {
            return Activator.CreateInstance(entry.Value);
        }
    }
