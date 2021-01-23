    [TestMethod]
    public void NewAction_deve_retornar_Authentication_IndexAction()
    {
        SetupTest();
        _mockAuthenticationService.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_deve_retornar_Repository_IndexAction()
    {
        SetupTest();
        _mockUsuarioRepository.VerifyAll();
    }
    
    [TestMethod]
    public void NewAction_deve_retornar_DBContext_IndexAction()
    {
        SetupTest();
        _mockDbContext.VerifyAll();
    }
    [TestMethod]
    public void NewAction_deve_retornar_Redirects_IndexAction()
    {
        var novoActionResult = SetupTest();
        novoActionResult.AssertActionRedirect().ToAction("Index");
    }
