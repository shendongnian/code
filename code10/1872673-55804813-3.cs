    var multiParamValues = new Dictionary<string, string[]>
    {
        {"ParamA", new[] {"1", "2"}},
        {"ParamB", new[] {"55", "56"}}
    };
    foreach (var paramValue in multiParamValues)
    {
        foreach (var value in paramValue.Value)
        {
            Console.WriteLine($"{paramValue.Key}, {value}");
        }
    }
