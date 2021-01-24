    public void GetInexKeyAsCallback() {
        //Arrange
        string actual = null;
        string expected = "domain.testKey";
        Mock<IConfiguration> configurationMock = new Mock<IConfiguration>(MockBehavior.Strict);
        configurationMock
            .Setup(_ => _[It.IsAny<string>()]) // <-- Use Setup
            .Callback((string arg) => actual = arg) // <<< the part here gets the parameter
            .Returns("mock");
        IConfiguration configuration = configurationMock.Object;
        //Act
        var result = configuration.GetDomainValue("testKey");
        //Assert
        Assert.AreEqual(expected, actual);
    }
