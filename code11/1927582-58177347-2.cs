    private static async Task<(string, DateTime)> DoAsyncTask(string name)
    {
       Console.WriteLine($"Do {name}");
       // simulate a delay
       await Task.Delay(5000);
    
       return (name, DateTime.Now);
    }
    
    private static void Handle((string, DateTime) someTuple)
    {
       Console.WriteLine($"Name {someTuple.Item1}, value {someTuple.Item2}");
    }
    
    public static async Task Main()
    {
       // List of names
       var nameArray = new[] { "task 1", "task 2", "task 3", "task 4", "task 5", "task 6", "task 7", };
    
       var options = new ExecutionDataflowBlockOptions()
                     {
                        EnsureOrdered = false,
                        MaxDegreeOfParallelism = 50
                     };
       var transform = new TransformBlock<string, (string, DateTime)>(DoAsyncTask, options);
       var actionBlock = new ActionBlock<(string, DateTime)>(Handle, options);
    
       transform.LinkTo(actionBlock, new DataflowLinkOptions(){PropagateCompletion = true});
    
       Console.WriteLine("Started " + DateTime.Now);
    
       foreach (var name in nameArray)
       {
          transform.Post(name);
       }
    
       transform.Complete();
    
       await actionBlock.Completion;
    
       Console.WriteLine("Finished " + DateTime.Now);
       Console.ReadKey();
    
    }
