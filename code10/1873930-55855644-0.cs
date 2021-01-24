    public Task ServePage1()
    {
        return Task.Run(async () => await DoThings(10));
    }
    public async Task ServePage2()
    {
        await Task.Run(async () => await DoThings(10));
    }
    public Task ServePage3()
    {
        return Task.Run(() => DoThings(10));
    }
    public async Task ServePage4()
    {
        await Task.Run(() => DoThings(10));
    }
