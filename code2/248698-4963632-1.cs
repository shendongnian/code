    // Arrange
    MyObject saveObject;
    mock.Setup(c => c.Method(It.IsAny<int>(), It.IsAny<MyObject>()))
            .Callback<int, MyObject>((i, obj) => saveObject = obj)
            .Returns("xyzzy");
    
    // Act
    // ...
    
    // Assert
    // Verify Method was called once only
    mock.Verify(c => c.Method(It.IsAny<int>(), It.IsAny<MyObject>()), Times.Once());
    // Assert about saveObject
    Assert.That(saveObject.TheProperty, Is.EqualTo(2));
