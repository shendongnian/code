    [SetUp]
    public void SetUp()
    {
       RouteCollection routes = new RouteCollection();
       MvcApplication.RegisterRoutes(routes);
       httpContextBaseStub = MockRepository.GenerateStub<HttpContextBase>();
       requestContext = new RequestContext(httpContextBaseStub, new RouteData());
       
       //urlHelper = new UrlHelper(requestContext);
       urlHelper = new UrlHelper(requestContext, routes);
    }
