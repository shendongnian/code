    var tasks = new List<Task>();
    
    foreach(item in listNeedInsert)
    {
        var task = RequestInsertToCosmosDB(item);
        tasks.Add(task);
    
        if(tasks.Count == 100)
        {
            await Task.WhenAll(tasks);
            tasks.Clear();
        }
    }
    
    // Wait for anything left to finish
    await Task.WhenAll(tasks);
