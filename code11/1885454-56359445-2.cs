    [TestMethod()]
    public void DefaultController_Should_GetProducts() {
        //Arrange
        var username = "name_here";
        var userId = 2;
        var identity = new GenericIdentity(username, "");
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
        identity.AddClaim(new Claim(ClaimTypes.Name, username));
        var principal = new GenericPrincipal(identity, roles: new string[] { });
        var user = new ClaimsPrincipal(principal);
        var controller = new DefaultController() {
            User = user //<-- Set the User on the controller directly
        };
        //Act
        var actionResult = controller.GetProducts();
        
        //Assert
        //...
    }
