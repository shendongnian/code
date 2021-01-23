    [Test]
    public void UsingPartialMocks()
    {
      MockRepository mocks = new MockRepository();
      ProcessorBase proc =  mocks.PartialMock<ProcessorBase>();
      Expect.Call(proc.Add(1)).Return(1);
      Expect.Call(proc.Add(1)).Return(2);
      mocks.ReplayAll();
      proc.Inc();
      Assert.AreEqual(1, proc.Register);
      proc.Inc();
      Assert.AreEqual(2, proc.Register);
      mocks.VerifyAll();
    }
