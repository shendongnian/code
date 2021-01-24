    var database = testServer.Host.Services.GetService<CustomDbContext>();
    
    foreach (var obj in database.Objects)
        {
            var taskDbContext = testServer.Host.Services.GetService<CustomDbContext>();
            tasks.Add(CustomAsyncMethod(obj.Name, taskDbContext , configuration, httpClient));
        }
