    [SetUp]
    public void SetUp()
    {
      RouteCollection routes = new RouteCollection();
      MvcApplication.RegisterRoutes(routes);
      //httpContextBaseStub = (new Moq.Mock<HttpContextBase>()).Object;
      var request = new Mock<HttpRequestBase>();
      var response = new Mock<HttpResponseBase>();
      response.Setup(r => r.ApplyAppPathModifier(It.IsAny<string>())).Returns((String url) => url);
      var mockHttpContext = new Mock<HttpContextBase>();
      mockHttpContext.Setup(c => c.Request).Returns(request.Object);
      mockHttpContext.Setup(c => c.Response).Returns(response.Object);
      requestContext = new RequestContext(mockHttpContext.Object, new RouteData());
      urlHelper = new UrlHelper(requestContext, routes);
    }
