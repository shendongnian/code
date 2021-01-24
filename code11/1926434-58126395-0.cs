    [Test]
    public void AddUser(){
        //Arrange
        AppUser expected = new AppUser();
        GreenCardController controller = new GreenCardController();
        //Act
        ActionResult<AppUser> actionResult = controller.UpdateArgosUser(expected);
        CreatedAtRouteResult result = actionResult.Result as CreatedAtRouteResult;
        AppUser actual = result.Value as AppUser;
        //Assert
        Assert.AreEqual(expected, actual);
    }
