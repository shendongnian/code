    List<Task> tasks = new List<Task>();
    try
    {
      tasks.Add(SendUsersBirthdayEmailsAsync());
      tasks.Add(DeleteOutdatedLogsAsync());
      tasks.Add(SendSystemNotificationsAsync());
      Task.WhenAll(tasks); // waits for all tasks to finish
    }
    catch (Exception e)
    {
       //Log e.ToString(); will give you all inner exceptions of the aggregate exception as well
    }
