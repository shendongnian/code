    private X MockX()
    {
      return MockX(100);  
    }
    
    private X MockX(int returnValue)
    {
      var x = MockRepository.GenerateStub<X>();
      someStub.Stub(x => x.SomeMethod(1)).Return(returnValue);
      return x;
    }
