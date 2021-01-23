    for (int i=0; i< TasksToShow.Count(); i++) onlineRepository.Tasks)
    {
        if ((TasksToShow!= onlineRepository[i].Tasks) && (TasksToShow.TaskID == onlineRepository.Tasks[i].TaskID))
        {
            tempLocalTasks.Add(TasksToShow);
            tempOnlineTasks.Add(onlineRepository.Tasks[i]);
        }
    }
