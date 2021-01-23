    var yourInitialTask = new Task(delegate
    {
        throw e;
    });
    var continuation = task.ContinueWith(t =>
    {
        if (task.IsCanceled)
        {
            Debug.WriteLine("IsCanceled: " + job.GetType());
        }
        else if (task.IsFaulted)
        {
            Debug.WriteLine("IsFaulted: " + job.GetType());
        }
        else if (task.IsCompleted)
        {
            Debug.WriteLine("IsCompleted: " + job.GetType());
        }
    }, TaskContinuationOptions.ExecuteSynchronously); //or consider removing execute synchronously if your continuation task is going to take long
    var wrapper = new Task(() =>
    {
       task.Start();
       continuation.Wait();
    });
    return wrapper;
