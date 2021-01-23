    [Test]
    public void UsingPartialMocks()
    {
      MockRepository mocks = new MockRepository();
      YourClass partialMock =  mocks.PartialMock<YourClass>();
      Expect.Call(partialMock.Notify(null)).IgnoreArguments();
      mocks.ReplayAll();
      partialMock.Initialize(null);
      mocks.VerifyAll();
    }
