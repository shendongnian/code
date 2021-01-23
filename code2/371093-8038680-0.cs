    foreach (Task onlineTask in onlineRepository.Tasks)
    {
        foreach (Task localTask in TasksToShow)
        {
            if ((localTask != onlineTask) && (localTask.TaskID == onlineTask.TaskID))
            {
                tempLocalTasks.Add(localTask);
                tempOnlineTasks.Add(onlineTask);
            }
        }
    }
