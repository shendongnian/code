    // arrange
    UrlActionContext actual = null;
    var userId = new Guid("52368a14-23fa-4c7f-a9e9-69b44fafcade");
    // prepare action context as necessary
    var actionContext = new ActionContext
    {
        ActionDescriptor = new ActionDescriptor(),
        RouteData = new RouteData(),
    };
    // create url helper mock
    var urlHelper = new Mock<IUrlHelper>();
    urlHelper.SetupGet(h => h.ActionContext).Returns(actionContext);
    urlHelper.Setup(h => h.Action(It.IsAny<UrlActionContext>()))
        .Callback((UrlActionContext context) => actual = context);
    // act
    var result = urlHelper.Object.UserEditPage(userId);
    // assert
    urlHelper.Verify();
    Assert.Equal("EditUser", actual.Action);
    Assert.Equal("Users", actual.Controller);
    Assert.Null(actual.RouteName);
    var values = new RouteValueDictionary(actual.Values);
    Assert.Equal(userId, values["id"]);
