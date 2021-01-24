    MLContext mlContext = new MLContext();
    
    var samples = new List<InputData>
    {
        new InputData { Age = 16 },
        new InputData { Age = 35 },
        new InputData { Age = 60 },
        new InputData { Age = 28 },
    };
    
    var data = mlContext.Data.LoadFromEnumerable(samples);
    
    Action<InputData, CustomMappingOutput> mapping =
        (input, output) =>
        {
            if (input.Age < 18)
            {
                output.AgeName = "Child";
            }
            else if (input.Age < 55)
            {
                output.AgeName = "Man";
            }
            else
            {
                output.AgeName = "Grandpa";
            }
        };
    
    var pipeline = mlContext.Transforms.CustomMapping(mapping, contractName: null);
    
    var transformer = pipeline.Fit(data);
    var transformedData = transformer.Transform(data);
    
    var dataEnumerable = mlContext.Data.CreateEnumerable<TransformedData>(transformedData, reuseRowObject: true);
    
    foreach (var row in dataEnumerable)
    {
        Console.WriteLine($"{row.Age}\t {row.AgeName}");
    }
