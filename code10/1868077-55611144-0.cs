    EventStreamResponse response = await client.OnAsync("user", (sender, args) => {
           System.Console.WriteLine(args.Path);
           System.Console.WriteLine(args.Data);
    });
    
    // Call dispose to stop listening for events
    // response.Dispose();
