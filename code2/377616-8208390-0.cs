    Task[] taskList = new Task[5];
    taskList[0] = System.Threading.Tasks.Task.Factory.StartNew(()=> ServiceCall1());
    taskList[1] = System.Threading.Tasks.Task.Factory.StartNew(()=> ServiceCall2());
    taskList[2] = System.Threading.Tasks.Task.Factory.StartNew(()=> ServiceCall3());
    taskList[3] = System.Threading.Tasks.Task.Factory.StartNew(()=> ServiceCall4());
    taskList[4] = System.Threading.Tasks.Task.Factory.StartNew(()=> ServiceCall5());
    System.Thread.Tasks.Task.WaitAll(taskList);
