    foreach (string path in paths)
    {
        var lambdaPath = path;
        var task = Task.Factory.StartNew(() =>
            {
                Boolean taskResult = ProcessPicture(lambdaPath);
                return taskResult;
            });
        task.ContinueWith(t => result &= t.Result);
        tasks.Add(task);
    }
