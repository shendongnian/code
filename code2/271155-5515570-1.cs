    // arrange
    var authService = MockRepository.GenerateStub<IAuthenticationService>();
    var sut = new AdminController(authService);
    new TestControllerBuilder().InitializeController(sut);
    var userInfo = new RegisterModel();
    userInfo.Email = "the_email@domain.com";
    authService
        .Stub(x => x.EmailIsUnique(userInfo.Email))
        .Return(false);
    
    // act
    var actual = sut.Register(userInfo);
    
    // assert
    actual
        .AssertViewRendered()
        .WithViewData<RegisterModel>()
        .ShouldEqual(userInfo, "");
