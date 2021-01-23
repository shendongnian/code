    void ScheduleNext()
    {
       var tasks = GetTasksByTimeAscending();
       var nextTask = tasks.FirstOrDefault();
       if (nextTask == null) return;
       
       System.Threading.Task.Factory.StartNew(() => MyScheduler(nextTask));
    }
    
    void MyScheduler(MyTask task)
    {
       var now = DateTime.Now;
       if (task.StartTime > now)
       {
          var timeToWait = task.StartTime.Substract(now);
          System.Threading.Thread.Sleep(timeToWait);
       }
    
       System.Threading.Task.Factory.StartNew(task.Action);
       ScheduleNext();
    }
