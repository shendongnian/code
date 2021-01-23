            var runSync = Task.Factory.StartNew(new Func<Task>(async () =>
            {
                Trace.WriteLine("Task runSync Start");
                await TaskEx.Delay(2000); // Simulates a method that returns a task and
                                          // inside it is possible that there
                                          // async keywords or anothers tasks
                Trace.WriteLine("Task runSync Completed");
            })).Unwrap();
            Trace.WriteLine("Before runSync Wait");
            runSync.Wait();
            Trace.WriteLine("After runSync Waited");
    
