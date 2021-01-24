    Context context = new Context();
    IObjectContextAdapter objectContextAdapter = (IObjectContextAdapter)context;
    object configuration = objectContextAdapter.ObjectContext.CreateObjectSet<Foo>()
        .EntitySet
        .MetadataProperties
        .Where(x => x.Name == "Configuration")
        .First()
        .Value;
    var propertyIndexes = configuration.GetType().GetProperty("PropertyIndexes", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(configuration);
    var list = (System.Collections.IEnumerable)propertyIndexes;
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
