    string url;
    if (CollectedLinks.TryTake(out url))
    {
      var queued = false;
      while (!queued)
      {
        // Loops thru the array looking for empty slot (null)
        for (byte i = 0; i < TaskArray.Length; i++)
        {
          if (TaskArray[i] == null)
          {
            TaskArray[i] = new Task(FindLinks, url, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
            TaskArray[i].Start(TaskScheduler.Current);
            queued = true; break;
          }
        }
    
        if (!queued)
        {
          // Loop and clean the array
          for (var i = 0; i < TaskArray.Length; i++)
          {
            if (TaskArray[i] == null)
              continue;
            if (TaskArray[i].Status == TaskStatus.RanToCompletion || TaskArray[i].Status == TaskStatus.Canceled || TaskArray[i].Status == TaskStatus.Faulted)
            {
              TaskArray[i].Wait(0);
              TaskArray[i] = null;
            }
          }
        }
      }
    }
