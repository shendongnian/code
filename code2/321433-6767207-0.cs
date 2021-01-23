    private List<string> _endpointLists = new List<string>() { "127.0.0.0:1234" };
    private static ChannelFactory<IWCFServiceChannel> _channelFactory = new ChannelFactory<ServiceReference.IWCFServiceChannel>("App.config Binding Name Here");
    private List<WCFServiceChannel> _serviceChannels = new List<WCFServiceChannel>();
    foreach (string uriEndpoint in _endpointLists)
        _serviceChannels.Add(_channelFactory.CreateChannel(new EndpointAddress(uriEndpoint)));
    _serviceChannels[0].Open();
    ...
