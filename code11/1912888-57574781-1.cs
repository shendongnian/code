    public async Task Post_Should_Return_Ok_WhenLoginSucceeds() {
        //Arrange
        var logger = Mock.Of<ILogger<AuthController>>();
        
        var user = new Users {
            UserId = 13,
            Name = "administrator",
            Password = "test123",
            Active = 1,
            Rights = -1,
            UserGuid = Guid.Parse("7ED0E003-45EF-4C93-B89F-05BF5047F151")
        };
        var login = new LoginModel(user.Name, user.Password);
        
        var userService = new Mock<IUserService>();
        userService
            .Setup(_ => _.IsUserAuthenticated(login.UserName, login.Password))
            .Returns(true);
        userService
            .Setup(_ => _.GetResponseToken(login.UserName))
            .ReturnsAsync(user);
        
        var controller = new AuthController(userService.Object, logger);
        
        //Act
        var result = await controller.Post(login);
    
        //Assert
        var statusCode = ((ContentResult)result).StatusCode;
        Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
    }
