    Type type = AppDomain.CurrentDomain.GetAssemblies().ToList()
        .SelectMany(s => s.GetTypes())
        .FirstOrDefault(p => type.IsAssignableFrom(p));
    if (type != null)
    {
        // create instance
    }
