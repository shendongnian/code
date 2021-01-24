    IList<Input> inputs = new List<Input>();
    // populate inputs here
    IDictionary<Input, Output> associations = new Dictionary<Input, Output>();
    associations.AddRange(inputs.AsParallel()
                                .Select(i => new KeyValuePair(i, Process(i))));
