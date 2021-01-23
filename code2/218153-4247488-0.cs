    var query = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.IsEnum && t.IsPublic);
    foreach (Type t in query)
    {
        Console.WriteLine(t);
    }
