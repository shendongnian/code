    // Arrange
    // During the Arrange part, mock.MyMethod() gets called several times.
    
    var mockRep = new MockRepository();
    var mock = mockRep.dynamicMock<IFoo>();
    Expect.Call(mock.MyMethod()).Return("desired result").Repeat.Time("count");
    
    mock.Replay()
    
    // Act
    //test go here 
    
    // Assert
    mock.AssertWasCalled(x => x.MyMethod()).Repeat.Once();
