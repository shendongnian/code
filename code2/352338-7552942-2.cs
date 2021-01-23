    [TestMethod]
    public void Test()
    {
        ......
        .........
        var mockedControllerContext = new Mock<ControllerContext> ();
        mockedControllerContext.SetupGet(p => p.HttpContext.Session["key"]).Returns("A value in session");
        mockedControllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);    
        mockedControllerContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("An identity name");
        mockedControllerContext.SetupGet(p => p.HttpContext.Response.Cookies).Returns(new HttpCookieCollection ());
    
        HomeController controller = new HomeController();
        controller.ControllerContext = mockedControllerContext.Object;
        .....
        ......
    
    }
