    foreach (string path in paths)
    {
        string pathCopy = path;
        var task = Task.Factory.StartNew(() =>
            {
                Boolean taskResult = ProcessPicture(pathCopy);
                return taskResult;
            });
        // See note at end of post
        task.ContinueWith(t => result &= t.Result);
        tasks.Add(task);
    }
