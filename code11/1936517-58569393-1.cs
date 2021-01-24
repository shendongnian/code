    public async Task Register_Returns_BadRequest_On_Invalid_Model()
    {
      var testUsername = "TestUsername";
      var mockUserManager = new Mock<IUserManager>();
      mockUserManager.Setup(m => m.FindByNameAsync(testUsername))
        .Returns(Task.FromResult(**Not sure about this part**))
      var controller = new RegisterController(mockUserManager.Object);
    
      var result = await controller.Register(model: null);
    
      var actionResult = Assert.IsType<ActionResult<IdentityResult>>(result);
      Assert.IsType<BadRequestObjectResult>(actionResult.Result);
    }
