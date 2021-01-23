    [OperationBehavior(Impersonation = ImpersonationOption.Required)]
    public void MyServiceMethod(){
        DoStuff();
        ServiceSecurityContext securityContext = ServiceSecurityContext.Current;
        using (securityContext.WindowsIdentity.Impersonate()) {
              EndpointAddress backendServiceAddress = new EndpointAddress("net.pipe://localhost/TargetAppService");
              ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(new NetNamedPipeBinding(), backendServiceAddress);
              IService channel = channelFactory.CreateChannel();
                        
              channel.SetIdentity();
        }
    }
