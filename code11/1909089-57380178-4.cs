    [ResponseType(typeof(Session))]
    [Route("api/v1/async")]
    public Session async_status()
    {
        AsyncStatus();
        return new Session() {...};
    }
    private async Task<int> AsyncStatus()
    {
        await SyncMethod();
        return 42;
    }
    private async Task<int> SyncMethod()
    {
        await Task.Delay(1);
        Thread.Sleep(60000);
        return 42;
    }
