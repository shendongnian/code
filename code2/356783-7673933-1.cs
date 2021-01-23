    var tasks = new Dictionary<int, Task>();
    
    QueueJob(Job job)
    {
        lock(tasks)
          if (tasks.ContainsKey(job.UserID))
          {
             var lastTask = tasks[job.UserID];
             var newTask = new Task(()=>StartJob(job));
             lastTask.ContinueWith(_=>newTask.Start());
             tasks[job.UserID] = newTask;
          }
          else
                tasks[job.UserID] = Task.Factory.StartNew(()=>StartJob(job));                  
    }
