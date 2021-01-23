    public static InstanceContext site;
    public ServiceReference1.StockServiceClient proxy;
    static CallbackHandler()
    {
        site = new InstanceContext(new CallbackHandler()); // (*)
    }
    public CallbackHandler()
    {
        proxy = new ServiceReference1.StockServiceClient(site);
    }
