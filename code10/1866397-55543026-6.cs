    //Arrange
    List<string> someProperty = new List<string>();
    var mock = new Mock<ISomeInterface>();
    
    mock.SetupSet(m => m.SomeProperty = Capture.In(someProperty))
        .Verifiable();
    
    mock.SetupGet(m => m.SomeProperty).Returns(() => someProperty.Last());
    
    //Act
    mock.Object.SomeProperty = "test";
    
    //Assert
    Assert.AreEqual("test", mock.Object.SomeProperty);
