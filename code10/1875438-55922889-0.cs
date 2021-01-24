    // prepare action context as necessary
    var actionContext = new ActionContext
    {
        ActionDescriptor = new ActionDescriptor(),
        RouteData = new RouteData(),
    };
    // create url helper mock
    var urlHelper = new Mock<IUrlHelper>();
    urlHelper.SetupGet(h => h.ActionContext).Returns(actionContext);
    // …
    // act
    var result = UrlHelperExtensions.DoSomething(urlHelper.Object);
    // assert
    // …
