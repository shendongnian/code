    var tasks = new[] { 
    new { TaskId = 1, SubTaskId = "A", Timestamp = DateTime.Parse("2010-11-22 15:48:49.727")},
    new { TaskId = 1, SubTaskId = "B", Timestamp = DateTime.Parse("2010-11-22 16:24:51.117")},
    new { TaskId = 2, SubTaskId = "C", Timestamp = DateTime.Parse("2010-11-15 11:49:05.717")},
    new { TaskId = 2, SubTaskId = "D", Timestamp = DateTime.Parse("2010-11-15 14:02:11.467")}};
 
    var newestTasks = 
        from task in tasks
        group task by task.TaskId into g
        select g.Where(t => t.Timestamp == g.Max(t2 => t2.Timestamp)).Single();
    
    foreach (var task in newestTasks)
        Console.WriteLine("TaskId = {0}, SubTaskId = {1}, Timestamp = {2}", 
            task.TaskId, task.SubTaskId, task.Timestamp);
