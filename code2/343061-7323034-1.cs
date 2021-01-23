    [TestMethod]
    public void NewAction_should_return_Authentication_IndexAction()
    {
        SetupTest();
        _mockAuthenticationService.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_should_return_Repository_IndexAction()
    {
        SetupTest();
        _mockUsuarioRepository.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_should_return_DBContext_IndexAction()
    {
        SetupTest();
        _mockDbContext.VerifyAll();
    }
    [TestMethod]
    public void NewAction_should_return_Redirects_IndexAction()
    {
        var novoActionResult = SetupTest();
        novoActionResult.AssertActionRedirect().ToAction("Index");
    }
