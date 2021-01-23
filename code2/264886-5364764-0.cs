    UnityServiceBehavior: IServiceBehavior
    {
    ....
    public Func<Type, string, UnityInstanceProvider> InstanceProviderFunc;
    
    
    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    
    ...
    
                foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
                {
                    ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                    if (channelDispatcher != null)
                    {
                        foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                        {
                            endpointDispatcher.DispatchRuntime.InstanceProvider =
                                InstanceProviderFunc(serviceDescription.ServiceType, this.ContainerName);
    ....
    }
