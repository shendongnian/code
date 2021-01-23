    [Test]
    public void Mytest()
    {
       var mocks = new MockRepository();
       var someMock = mocks.DynamicMock<IFoo>();
       someMock.SomeMethod(1);
       LastCall.Return(100);
       someMock.SomeMethod(1);
       LastCall.Return(200);
       mock.Replay(); // stop recording, go to replay mode
       
       // actual test
       int firstResult = someMock.SomeMethod(1);
       int secondResult = someMock.SomeMethod(2);
    
       // verify the expectations that were set up earlier 
       // (will fail if SomeMethod is not called as in the recorded scenario)
       someMock.VerifyAll();
    }
