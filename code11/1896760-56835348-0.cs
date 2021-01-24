    var resultTasks = new List<VendorTaskResult>(orders.Count);
    orders.ToList().ForEach( item => {
        var result = new VendorTaskResult();
        try
        {
            result.Response = await result.CallVendorAsync();
        }
        catch(Exception ex)
        {
            result.Exception = ex;
        }
        resultTasks.Add(result);
        Thread.Sleep(x);
    });
    var results = Task.WhenAll(resultTasks);
