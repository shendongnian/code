    private static async Task<string> DoAsyncTask(string name)
    {
       Console.WriteLine($"Do {name}");
       // simulate a delay
       await Task.Delay(5000);
       return name;
    }
    
    private static async Task HandleAsync(Task<string> task)
    {
       var name = await task;
       Console.WriteLine($"Done {name}");
    }
    
    public static async Task Main()
    {
       // List of names
       var nameArray = new[] { "task 1", "task 2", "task 3", "task 4", "task 5", "task 6", "task 7", };
    
       Console.WriteLine("Started " + DateTime.Now);
    
       // pump the names in to do async, then the resulting tasks in toHandleAsync
       var taskList = nameArray.Select(DoAsyncTask)
                               .Select(HandleAsync);
    
       // wait for all tasks 
       await Task.WhenAll(taskList);
    
       Console.WriteLine("Finished " + DateTime.Now);
       Console.ReadKey();
    
    }
