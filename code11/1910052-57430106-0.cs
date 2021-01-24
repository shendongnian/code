    public async Task SendRequest()
    {
        var topic = "SomeTopic";
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 1);
        var responseHandler = new Action<ResponseMessage>(response =>
        {
            //signal that the response has arrived
            semaphoreSlim.Release();
        });
        bus.Subscribe(BusController.ManualRequest, responseHandler, configuration => configuration.WithTopic(BusController.ManualRequest));
        bus.Publish(someRequest, topic);
        //wait for the response to arrive
        await semaphoreSlim.WaitAsync();
        semaphoreSlim.Dispose();
    }
