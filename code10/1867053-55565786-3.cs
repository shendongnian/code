    public static async Task DoWorkLoads(IEnumerable <Something> results)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
    
       var block = new ActionBlock<Something>(MyMethodAsync, options);
    
       foreach (var result in results)
          block.Post(result);
    
       block.Complete();
       await block.Completion;
    
    }
    
    ...
    
    public async Task MyMethodAsync(Something result)
    {       
       await SomethingAsync(result);
    }
