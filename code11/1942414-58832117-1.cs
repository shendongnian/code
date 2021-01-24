    Console.WriteLine("Client started!");
    
    
    HubConnection connection = new HubConnectionBuilder()
        .WithUrl("https://localhost:44384/hub/TestHub")
        .Build();
    
    connection.StartAsync().Wait();
    
    Console.WriteLine("Client connected!");
    
    string line = null;
    while ((line = System.Console.ReadLine()) != null)
    {
        connection.InvokeAsync("HelloMethod", line);
    }
