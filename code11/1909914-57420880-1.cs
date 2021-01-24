    IList<Input> inputs = new List<Input>();
    // populate inputs here
    IDictionary<Input, Output> associations = new Dictionary<Input, Output>();
    associations.AddRange(inputs.AsParallel()
                            .Select(async i => 
                                { Output o = await Process(i); 
                                  return new KeyValuePair<Input, Output>(i, o);
                                }));
