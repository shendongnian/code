    var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, "username"),
        new Claim(ClaimTypes.NameIdentifier, "userId"),
        new Claim("name", "John Doe"),
    };
    
    var identity = new ClaimsIdentity(claims, "TestAuthType");
    var claimsPrincipal = new ClaimsPrincipal(identity);
    
    ControllerToTest controller = new ControllerToTest();
    ControllerToTest.ControllerContext.HttpContext = new DefaultHttpContext();
        
    ControllerToTest.ControllerContext.HttpContext.User = claimsPrincipal;
    
    ControllerToTest.Get();
