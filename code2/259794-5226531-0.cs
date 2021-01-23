    Queue<Task> starts = new Queue(fullResult.OrderBy(task => task.StartTime));
    Queue<Task> ends = new Queue(fullResult.OrderBy(task => task.EndTime));
    
    Dictionary<int, Task> activeTasks = new Dictionary<int, Task>();
    
    for(int i=0;i<oneMinuteIntervals;i++)
    { 
      DateTime current = ComputeDateTime(i);
        // may be needed
      // current = current.AddMinutes(1);
    
      while(starts.Any() && starts.Peek().StartTime < current)
      {
        Task startingTask = starts.Dequeue();
        activeTasks[startingTask.Id] = startingTask;
      }
    
      foreach(Task result in activeTasks.Values)
      {
        //Does stuff
      } 
    
      while(ends.Any() && ends.Peek().EndTime < current)
      {
        Task endingTask = ends.Dequeue();
        activeTasks[endingTask.Id] = null;
      }
    }
