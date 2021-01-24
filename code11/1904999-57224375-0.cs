    try
      {
        bool tasks_finished = false;
        tasks_finished = Task.WaitAll(tasks.ToArray(), new TimeSpan(0, 60, 0));
        if (!tasks_finished)
          foreach (var ongoing_task in tasks.ToArray())
            {
              if (ongoing_task.IsFaulted)
                throw ongoing_task.Exception;
            }
      }
    catch (Exception ex)
      {
        ...
        throw;
      }
