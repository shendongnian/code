    [TestMethod]
    public void NewAction_should_checkUserRegistered()
    {
        SetupTest();
        _mockAuthenticationService.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_should_GetUserByEmail()
    {
        SetupTest();
        _mockUsuarioRepository.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_should_SaveDBContext()
    {
        SetupTest();
        _mockDbContext.VerifyAll();
    }
    [TestMethod]
    public void NewAction_should_return_Redirects_Action()
    {
        var novoActionResult = SetupTest();
        novoActionResult.AssertActionRedirect().ToAction("Index");
    }
