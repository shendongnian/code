    [TestMethod]
    public void Test()
    {
    
        var context = new Mock<HttpContextBase>();
        var request = new Mock<HttpRequestBase>();
        context.Setup(c => c.Request).Returns(request.Object);
        
        HomeController controller = new HomeController();
    
        controller.ControllerContext = new ControllerContext( context , new RouteData(), controller );
        ....
        ...........
    }
