    // arrange
    var sut = new HomeController();
    var user = new GenericPrincipal(new GenericIdentity("foo"), null);
    var httpContext = new Mock<HttpContextBase>();
    httpContext.Setup(x => x.User).Returns(user);
    var context = new ControllerContext(new RequestContext(httpContext.Object, new RouteData()), sut);
    sut.ControllerContext = context;
    // act
    var actual = sut.Index();
    // assert
    ...
