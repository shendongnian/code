    public ActionResult MyTasks(int userId)
    {
        // will be separate cache for each user id, group all with name MyTasks
        var tasks = db.Task
            .ByAssignedId(userId)
            .ByStatus(Status.InProgress)
            .FromCache(CacheManager.GetProfile().WithGroup("MyTasks"));
    
        return View(tasks);
    }
    
    public ActionResult UpdateTask(Task task)
    {
        db.Task.Attach(task, true);
        db.SubmitChanges();
    
        // since we made an update to the tasks table, we expire the MyTasks cache
        CacheManager.InvalidateGroup("MyTasks");
    }
