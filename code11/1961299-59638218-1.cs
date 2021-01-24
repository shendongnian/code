    // Query just a single column
    var tasks = dbContext.Tasks
        .Where(t => t.UserId == userId)
        .Select(t => new Task { UserId = t.UserId, Sequence = t.Sequence })
        .ToList();
    // Update a single column and tell EF to track it
    for(int i = 0; i < tasks.Count; i++)
    {
        tasks[i].Sequence = i;
        dbContext.Attach(tasks[i]);
        dbContext.Entry(tasks[i]).Property(t => t.Sequence).IsModified = true;
    }
    // Save the changes to that column
    dbContext.SaveChanges();
