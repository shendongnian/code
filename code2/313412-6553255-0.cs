    var inputData = new Dictionary<string, string>();
    var itemStack = new Dictionary<string, string>();
    var oldStack = itemStack;
    itemStack = new[] { inputData.SkipWhile(d => oldStack.Keys.Contains(d.Key)), itemStack }
       .SelectMany(d => d)
       .ToDictionary(d => d.Key, d => d.Value);
