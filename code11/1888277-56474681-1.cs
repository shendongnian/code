    [Fact(Timeout = 1000)]
    public async void ShouldTimeout()
    {
        await Task.Delay(3000);
    }
