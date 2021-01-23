    // Arrange - Build the necessary state variables into the stubbed method invocations.
    bool wasMethod1Called;
    bool wasMethod2Called;
    bool wasMethod2CalledBeforeMethod1;
    bool wasMethod3CalledBeforeMethod2;
    var mock = MockRepository.GenerateMock<ISomeService>();
    mock.Stub(m => m.Method1()).WhenCalled(inv =>
    {
        wasMethod1Called = true;
    });
    mock.Stub(m => m.Method2()).WhenCalled(inv =>
    {
        wasMethod2Called = true;
        wasMethod2CalledBeforeMethod1 = !wasMethod1Called;
    });
    mock.Stub(m => m.Method3()).WhenCalled(inv =>
    {
        wasMethod3CalledBeforeMethod2 = !wasMethod2Called;
    });
    // Act
    myObject.Service = mock;
    // Assert - Ensure each expected method was called, and that they were called in the right order.
    mock.AssertWasCalled(m => m.Method1());
    mock.AssertWasCalled(m => m.Method2());
    mock.AssertWasCalled(m => m.Method3());
    Assert.That(wasMethod2CalledBeforeMethod1, Is.False, "Method2 cannot be called before Method1.");
    Assert.That(wasMethod3CalledBeforeMethod2, Is.False, "Method3 cannot be called before Method2.");
