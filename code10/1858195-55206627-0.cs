    //Arrange
    var principal = new Mock<ClaimsPrincipal>();
    principal
        .Setup(m => m.FindFirst(It.IsAny<string>()))
        .Returns(new Claim("name", "John Doe"));
    
    //Act
    string value = principal.Object.FindFirstValue("claimType", true);
    
    //Assert
    Assert.AreEqual("John Doe", value);
