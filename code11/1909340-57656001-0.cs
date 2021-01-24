    private static async void SendMsg ()
    {
        var hub = new HubConnection("http://localhost:6692");
        var proxy = hub.CreateHubProxy("ChatHub");
        await hub.Start().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Console.WriteLine($"Failed to connect due to task.Exception.GetBaseException()}");
            else
                Console.WriteLine($"Connected: {task.Status}");
        });
        await proxy.Invoke<string>("Send", "Console", "Testing");
        Console.WriteLine("SendMsg finished");
    }
