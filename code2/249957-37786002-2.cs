    // Arrange
    var controller = new FoosController();
    // Act
    var result = await controller.Get();
    // Assert
    var resultObject = Assert.IsType<JsonResult>(result);
    dynamic resultData = new JsonResultDynamicWrapper(resultObject);
    Assert.Equal("Bar", resultData.Bar);
    Assert.Equal("Baz", resultData.Baz);
