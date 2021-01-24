    List<TaskGroup> data = context.TableName
        .GroupBy(x => x.GroupingProperty)
        .Select(grp => new TaskGroup 
        {
            Key = grp.Key,
            Tasks = grp.Select(task => new TaskViewModel
            {
                Name = task.Task,
                Assignee = task.Name,
                // etc
            })
            .ToList()
        })
        .ToList();
