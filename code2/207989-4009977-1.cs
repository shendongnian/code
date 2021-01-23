    var query = foo.GetType()
                   .GetProperties(BindingFlags.Public |
                                  BindingFlags.Instance)
                   // Ignore indexers for simplicity
                   .Where(prop => !prop.GetIndexParameters().Any())
                   .Select(prop => new { Name = prop.Name,
                                         Value = prop.GetValue(foo, null) });
                
    foreach (var pair in query)
    {
        Console.WriteLine("{0} = {1}", pair.Name, pair.Value);
    }
