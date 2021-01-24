    private readonly _httpClient = new HttpClient();
    var tasks = new List<Task>();
    foreach(var url in urls)
    {
        var task = DoWork(url);
        tasks.Add(task);
    }
    await Task.WhenAll(tasks);
    foreach(var task in tasks)
    {
      if (task.Exception != null)
        Console.WriteLine(task.Exception.Message);
    }
    public async Task DoWork(string url)
    {                
      var json = await _httpClient.GetAsync(url);
      // do something with json
    }
                                                                                                       
