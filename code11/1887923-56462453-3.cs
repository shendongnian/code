    public ICommand TestCommand { get; }
    private Task TestMethod(object p)
    {
        return Task.Delay(1000);
    }
    ...
    TestCommand = new AsyncCommand(TestMethod);
