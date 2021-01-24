    try
    {
        HubConnection connection = new HubConnectionBuilder()
        .WithUrl("http://localhost:61262/chatHub")
        .Build();
    
        await connection.StartAsync();
    
        var mes = "hello";
    
        await connection.InvokeAsync("SendMessage", "Consloe Client", mes);
    
        // await connection.StopAsync();
    }
    catch (Exception ex)
    {
    
        Console.WriteLine("Can not communicate with server now, please retry later.");
    }
