      // Producer:
      Task.Run(() => { 
        for (int i = 0; i < 1000; i++)
          blockingCollection.Add(i);
        blockingCollection.CompleteAdding();
      });    
      // Consumers:
    
      Task.Run(() => {
        foreach (var item in blockingCollection.GetConsumingEnumerable()) 
          Console.WriteLine("Taskid{1} Item {0}", item, Task.CurrentId);
      });
      Task.Run(() => {
        foreach (var item in blockingCollection.GetConsumingEnumerable()) 
          Console.WriteLine("Taskid{1} Item {0}", item, Task.CurrentId);
      });
