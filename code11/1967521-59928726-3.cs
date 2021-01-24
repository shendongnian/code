    var jobs = new List<int>(){1, 2, 3 };
    jobs.ForEach(j => 
       {
           var myTask = Task.Factory.StartNew(() => 
           {
               Console.WriteLine($"This is a current number of executing task: { j }");
               Thread.Sleep(5000); // Imitation of long-running operation
               Console.WriteLine($"Executed: { j }");
           },  TaskCreationOptions.LongRunning);
           myTask.Wait();
        });
    Console.WriteLine($"All jobs are executed");
