    var tasks = new List<Task<Response<Person>>>();
    const int maxCalls = 100;
    
    Parallel.For(0, maxCalls, (i) =>
    {
        var client = clientFactory.CreateClient();
        tasks.Add(client.GetAsync<Person>(new Uri("JsonPerson", UriKind.Relative)));
    });
    
    var results = await Task.WhenAll(tasks);
