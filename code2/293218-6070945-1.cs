    private IMyServiceContract GetLocalClient(string serviceEndpointName)
    {
        var factory = new ChannelFactory<IMyServiceContract>(serviceEndpointName);
        return factory.CreateChannel();
    }
