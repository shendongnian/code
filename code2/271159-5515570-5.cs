    private IAuthenticationService _authService;
    private AdminController _controller;
    private TestControllerBuilder _builder;
    
    Setup()
    {
        _authService = MockRepository.GenerateStub<IAuthenticationService>();
        _controller = new AdminController(_authService);
        _builder = new TestControllerBuilder();
        _builder.InitializeController(_controller);
    }
    
    [Test]
    public void Register_Post_AddModelErrorWhenEmailNotUnique()
    {
        // arrange
        var userInfo = new RegisterModel();
        userInfo.Email = "the_email@domain.com";
        _authService
            .Stub(x => x.EmailIsUnique(userInfo.Email))
            .Return(false);
        
        // act
        var actual = _controller.Register(userInfo);
        
        // assert
        actual
            .AssertViewRendered()
            .WithViewData<RegisterModel>()
            .ShouldEqual(userInfo, "");
        Assert.IsFalse(_controller.ModelState.IsValid);
    }
