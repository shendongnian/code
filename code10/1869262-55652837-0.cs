    try
    {
        var tasksresult = await Task.WhenAll(tasks);
        return tasksresult.ToList();
    }
    catch (Exception e)
    {
        foreach (var task in tasks)
        {
            if (task.IsFaulted)
            {
                var taskException = task.Exception.InnerException;
                // ^^ Assuming that each task cannot have more than one exception inside its AggregateException.
                if (taskException is SwaggerException swaggerException)
                {
                    if (swaggerException.StatusCode == 404)
                    {
                        _logger.Info($"user with Id {userId} does not exist");
                    }
                    else
                    {
                        _logger.Error("Unable to fetch user", swaggerException);
                    }
                }
                else
                {
                    _logger.Error("An unexpected task error occurred", taskException);
                }
            }
        }
        if (!tasks.Any(t => t.IsFaulted))
        {
            _logger.Error("A non task-related error occurred", e);
        }
    }
