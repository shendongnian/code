    #Arrange
        var mock = new Mock<ITableStorageRepository>();
    
    mock.Setup(.... etc.
    
    var systemUnderTest = new TheServiceImActuallyTesting(mock.Object);
    
    #Act
    
    var resp = systemUnderTest.GetStuff(query);
    
    #Assert
