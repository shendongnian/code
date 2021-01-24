    Dictionary<string, object> values = new Dictionary<string, object>()
    {
        { "Property1", "MyValue" },
        { "Property2", 1234 },
        { "Property3", true },
    };
    
    MyType myType = new MyType();
    var accessor = TypeAccessor.Create(typeof(MyType));
    foreach (var entry in values)
        accessor[myType, entry.Key] = entry.Value;
