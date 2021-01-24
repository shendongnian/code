    var tasks = new List<Task>();
    
    tasks.Add(DoWorkAsync(1));
    tasks.Add(DoWorkAsync(2));
    tasks.Add(DoWorkAsync(3));
    tasks.Add(DoWorkAsync(4));
    tasks.Add(DoWorkAsync(5));
    tasks.Add(DoWorkAsync(6));
    
    await Task.WhenAll(tasks.ToArray());
