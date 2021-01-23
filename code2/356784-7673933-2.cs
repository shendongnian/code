    var tasks = new Dictionary<int, Task>();
    
    QueueJob(Job job)
    {
        lock(tasks)
          if (tasks.ContainsKey(job.UserID))
          {
             var newTask = tasks[job.UserID].ContinueWith(_=>StartJob(job));
             tasks[job.UserID] = newTask;
          }
          else
                tasks[job.UserID] = Task.Factory.StartNew(()=>StartJob(job));                  
    }
