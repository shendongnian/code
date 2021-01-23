    IDictionary<string, object> foo = new ExpandoObject();
    foreach (var pair in values)
    {
        foo[pair.Key] = pair.Value;
    }
    dynamic d = foo;
    string name = d.Name;
    string age = d.Age; // This will still be a string, not an int
