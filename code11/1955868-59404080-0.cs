    //Arrange
    string value = "value";
    var mockObject = new Mock<ObjectType>();
    mockObject.SetupAllProperties();
    
    ClassUnderTest classUnderTest = new ClassUnderTest();
    //Act
    var result = classUnderTest.SetProperty(value, mockObject.Object);
    
    //Assert
    Assert.That(result.property, Is.EqualTo(value));
