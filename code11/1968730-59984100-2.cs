    Dictionary<string, Action> tests = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.FullName.StartsWith("MyTests.Test"))
        .Select(t => t.GetMethod("Test"))
        .ToDictionary(m => m.DeclaringType.Name,
            m => new Action(() => m.Invoke(null, null)));
    tests["Test1"]();
    tests["Test2"]();
