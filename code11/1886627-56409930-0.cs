    var getResponseTasks = new List<Task<Response<CheckOrderStatus>>>();
    foreach(var serviceAdress in _serviceAddresses)
    {
        var client = bus.CreateRequestClient<CheckOrderStatus>(serviceAddress);
        getResponseTasks.Add(client.GetResponse<OrderStatusResult>(new { OrderId = id}));
    }
    
    await Task.WhenAll(getResponseTasks);
