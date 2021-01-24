    private static async Task<List<DeviceResponseData>> GetResponseData(MyClient client, Action<DeviceResponseData> update, int timeout = 5000)
    {
       var cancellationToken = new CancellationTokenSource(timeout);
       ...
       while (!cancellationToken.IsCancellationRequested)
       {
          // Wait indefinitely until any message is received.
          var response = await client.ReceiveAsync(cancellationToken.Token);
    
          var result = new DeviceResponseData( /* ... */ response);
    
          data.Add(result);
          update(result);
    
       }
       ...
    }
