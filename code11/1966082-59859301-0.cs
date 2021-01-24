    //Arrange
    var httpContext = new DefaultHttpContext();
    var context = new ActionExecutingContext(
        new ActionContext {
            HttpContext = httpContext,
            RouteData = new RouteData(),
            ActionDescriptor = new ActionDescriptor(),
        },
        new List<IFilterMetadata>(),
        new Dictionary<string, object>(),
        new Mock<Controller>().Object); //<-- while mock used here, it can be 
                                        //replaced with subject controller under test
    ActionExecutionDelegate next = new ActionExecutionDelegate(() => Task.FromResult(context));
    //...
