    //Arrange
    string someProperty = null;
    var mock = new Mock<ISomeInterface>();
    
    mock.SetupSet(m => m.SomeProperty = It.IsAny<string>())
        .Callback<string>(p => someProperty = p)
        .Verifiable();
    
    // use func instead of value to defer the resulution to the invocation moment
    mock.SetupGet(m => m.SomeProperty).Returns(() => someProperty);
    
    //Act
    mock.Object.SomeProperty = "test";
    //Assert
    Assert.AreEqual("test", mock.Object.SomeProperty);
