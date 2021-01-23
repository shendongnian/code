    // Arrange
    var mock = MockRepository.GenerateMock<ICustomType>();
    var service = new MyService(mock);
    
    // Act
    service.DoSomething();
    
    // Assert 
    // ensures that SomeMethod of the mock was called 
    // whilst service.DoSomething() call
    mock.AssertWasCalled(m => m.SomeMethod());
