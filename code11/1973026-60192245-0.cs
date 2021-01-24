    var task1 = Task.Factory.StartNew<List<X>>(() => Helper1.GetStuff(), TaskCreationOptions.LongRunning));
    var task2 = Task.Factory.StartNew<List<Y>>(() => Helper2.GetStuff(), TaskCreationOptions.LongRunning);
    
    var allTasks = new Task[] { task1, task2 };
    
    Task.WaitAll(allTasks);
    
    List<X> lst1 = task1.Result;
    List<Y> lst2 = task2.Result;
