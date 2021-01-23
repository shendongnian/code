    private IMvcApplication _app;
    private RouteCollection _routes;
    
    [TestInitialize]
    public void InitializeTests()
    {
        _app = new MyCustomApplication();
    
        _routes = new RouteCollection();
        _app.RegisterRoutes(_routes);
    }
