         // Create an array of methods to run
         Func<object, List<WRecord>>[] methods = new[]
                                                   {
                                                      s => GetRecordsOfAAA((string) s),
                                                      s => GetRecordsOfBBB((string) s),
                                                      s => GetRecordsOfCCC((string) s)
                                                   };
         // Create an array of tasks
         Task<List<WRecord>>[] tasks = new Task<List<WRecord>>[methods.Length];
         // Create and start each task
         for (int i = 0; i < tasks.Length; i++)
         {
            tasks[i] = Task<List<WRecord>>.Factory.StartNew(methods[i], heart);
         }
         // Wait for all tasks to complete. Results are in tasks[n].Result
         Task.WaitAll(tasks);
        
         
