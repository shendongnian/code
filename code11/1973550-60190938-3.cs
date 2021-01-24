    public HttpMessageHandler CreateHandler()
    {
        var pathBase = BaseAddress == null ? PathString.Empty : PathString.FromUriComponent(BaseAddress);
        return new ClientHandler(pathBase, Application) { AllowSynchronousIO = AllowSynchronousIO, PreserveExecutionContext = PreserveExecutionContext };
    }
    public HttpClient CreateClient()
    {
        return new HttpClient(CreateHandler()) { BaseAddress = BaseAddress };
    }
