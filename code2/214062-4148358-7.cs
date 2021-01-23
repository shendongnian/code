    public static InstanceContext site;
    public static ServiceReference1.StockServiceClient proxy;
    static CallbackHandler()
    {
        site = new InstanceContext(new CallbackHandler());
        proxy = new ServiceReference1.StockServiceClient(site);
    }
