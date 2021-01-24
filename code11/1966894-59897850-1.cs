    // Create a list of tasks
    var imageTasks = new List<Task<Image>>();
    
    // Use ForEachAsync to add tasks to the list
    await users.ForEachAsync(u => imageTasks.Add(DownloadImageAsync(u.ImageId)));
    
    // Wait for all tasks to complete
    IEnumerable<Image> images = await Task.WhenAll(imageTasks);
