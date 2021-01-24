    var inputsAndTasks = new List<(Input Input, Task<Output> OutputTask)>();
    foreach (var input in inputs)
    {
        Task<Output> output = Process(input);
        inputsAndTasks.Add((input, output));
    }
    
    await Task.WhenAll(inputsAndTasks.Select(i => i.OutputTask));
    var results = new List<(Input, Output)>();
    foreach (var x in inputsAndTasks)
    {
        Output output = await x.OutputTask;
        results.Add((x.Input, output));
    }
