    [Fact]
    public async Task Function_ReturnBadRequest() {
        //Arrange
        var expectedValue = new StringValues("Hello World"); //Or what you want
        var request = new Mock<HttpRequest>();
        request
            .Setup(_ => _.Query["EnterpriseId"])
            .Returns(expectedValue);
    
        var logger = new MockLogger();
    
        //Act
        var actualResult = await GetUserRolePageMapping.Run(request.Object, logger);
    
        //Assert
        actualResult.Should().BeOfType<HttpResponseMessage>();
    }
