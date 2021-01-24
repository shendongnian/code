    public ISender EmailSender
    {
        get
        {
            var cpa = (IContainerProviderAccessor)this.Context.ApplicationInstance;
            return cpa.ContainerProvider.RequestLifetime.ResolveNamed<ISender>("email");
        }
    }
