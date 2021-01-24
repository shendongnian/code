      private async Task MyExecution() {
        var tasks = new[] {
          //TODO: Task.Run is a better option than Task.Factory.StartNew
          Task.Factory.StartNew(() => GetSomething1()),
          Task.Factory.StartNew(() => GetSomething2()),
          Task.Factory.StartNew(() => GetSomething3())
        };
    
        // Await until all tasks are completed 
        await Task.WhenAll(tasks);
    
        // Since all tasks are completed, we can query for their `Result`s:
        var things = tasks
          .Select(task => task.Result) // or task => await task
          .ToArray();
    
        for (int i = 0; i < things.Length; ++i) 
          Console.WriteLine($"Task #{i + 1} returned {things[i]}");
        ... 
      }
