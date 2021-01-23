    private RouteCollection _routes;
    private MyCustomAreaRegistration _area;
        
    [TestInitialize]
    public void InitTests()
    {
        _routes = new RouteCollection();
        var context = new AreaRegistrationContext("MyCustomArea", _routes);
        
        _area.RegisterArea(context);
    }
