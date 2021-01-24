    public async Task Index_Should_Be_Forbidden() {
        // Arrange
        var authService = Mock.Of<IAuthorizationService>(_ =>
            _.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), null, It.IsAny<string>()) == AuthorizationResult.Failed()
        );
        //Create test user with what ever claims you want
        var displayName = "UnAuthorized User name";
        var identity = new GenericIdentity(displayName);
        var principle = new ClaimsPrincipal(identity);
        // use default context with user
        var httpContext = new DefaultHttpContext() {
            User = principle
        }
        //need these as well for the page context
        var modelState = new ModelStateDictionary();
        var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
        var modelMetadataProvider = new EmptyModelMetadataProvider();
        var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
        // need page context for the page model
        var pageContext = new PageContext(actionContext) {
            ViewData = viewData
        };
        //create model with necessary dependencies
        var model = new IndexModel(authService) {
            PageContext = pageContext //context includes User 
        };
        //Act
        var result = await model.OnGet();
        
        //Assert
        result.Should()
            .NotBeNull()
            .And.BeOfType<ForbidResult>();
    }
