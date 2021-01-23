    [SetUp]
    private void Setup()
    {
        _mockHttpContext = new Mock<HttpContextBase>();
        _mockStaticMembership = new Mock<IStaticMembershipService>();           
        _mockUser = new Mock<MembershipUser>();
        _mockPrincipalUser = new Mock<IPrincipal>();        
            
        _mockHttpContext.Setup(http => http.User).Returns( _mockPrincipalUser.Object );
        _mockPrincipalUser.Setup(principal => principal.Identity.Name).Returns("myname");
        _mockUser.Setup(user => user.ProviderUserKey).Returns( Guid.NewGuid() );
            
        _mockStaticMembership.Setup(membership => membership.GetUser(It.IsAny<string>())).Returns( _mockUser.Object );
    
    }
            
    [Test]
    public void Some_Test_For_My_Controller()
    {            
        var controller = new MyController( _mockStaticMembership.Object );            
        controller.ControllerContext = new ControllerContext(_mockHttpContext.Object, new RouteData(), controller);
            
        //Test your action and verify   
    }
