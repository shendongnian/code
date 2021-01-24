    using (var actAndAssertContext = new ApplicationDbContext(options))
    {
         var sut = new AvatarController(userManagerWrapperMock.Object, hostingEnvironmentMock.Object, actAndAssertContext);
         sut.ControllerContext.HttpContext.User = null;
    }
