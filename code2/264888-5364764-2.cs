    public class UnityBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new UnityServiceBehavior()
            {
                InstanceProviderFunc = InstanceProviderFunc(),
                ContainerName = this.ContainerName,
                ContextChannelEnabled = this.ContextChannelEnabled,
                InstanceContextEnabled = this.InstanceContextEnabled,
                OperationContextEnabled = this.OperationContextEnabled,
                ServiceHostBaseEnabled = this.ServiceHostBaseEnabled
            };
        }
    
        protected virtual Func<Type, string, UnityInstanceProvider> InstanceProviderFunc()
        {
            return (type, str) => new UnityInstanceProvider(type, str, UnityInstanceProvider.CreateUnityContainer);
        }
    }
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
