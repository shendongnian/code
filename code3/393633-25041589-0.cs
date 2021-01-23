    // Arrange - Build the necessary assertions into the stubbed method invocations.
    var mock = MockRepository.GenerateMock<ISomeService>();
    mock.Stub(m => m.Method1()).WhenCalled(inv => mock.AssertWasNotCalled(m => m.Method2()));
    mock.Stub(m => m.Method2()).WhenCalled(inv => mock.AssertWasNotCalled(m => m.Method3()));
    // Act
    myObject.Service = mock;
    // Assert - Ensure each expected method was called.
    mock.AssertWasCalled(m => m.Method1());
    mock.AssertWasCalled(m => m.Method2());
    mock.AssertWasCalled(m => m.Method3());
