    [Fact]
    public async Task MyUnitTest() {
        // Arrange
        var mockController = new Mock<WeatherForecastController>() {
            CallBase = true; //so that it can call `HasAccess` without issue
        };
        // Act
        ActionResult<WeatherForecast[]> actionResult = await mockController.Object.Get(); 
        // Assert
        Assert.IsNotNull(actionResult);
        var returnValue = Assert.IsType<WeatherForecast>(actionResult.Value);
    }
