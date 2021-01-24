    var lists = new List<int>(){1, 2, 3 };
    lists.ForEach(s => 
       {
           var myTask = Task.Factory.StartNew(() => 
           {
               Console.WriteLine($"This is a current number of executing task: { s }");
               Thread.Sleep(5000);
               Console.WriteLine($"Executed: { s }");
           },  TaskCreationOptions.LongRunning);
           myTask.Wait();
        });
    Console.WriteLine($"All jobs are executed");
