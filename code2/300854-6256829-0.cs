    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      var host = base.CreateServiceHost(serviceType, baseAddresses);
      host.Extensions.Add(new CustomConfigurer());
      return host;
    }
