    public void Start(String[] args)
    {
        var dispatchConfig = this.GetDispatchConfiguration();
        DispatchConfiguration.ConfigureStructureMap(ObjectFactory.Container, dispatchConfig);
        ...
    }
    private IDispatchConfiguration GetDispatchConfiguration()
    {
        var config = (DispatchSettings)ConfigurationManager.GetSection("DispatchSettings");
        return config;
    }
