    protected int ReturnVal{get; set;}
    public void Init()
    {
    someStub = MockRepository.GenerateMock<ISomeStub>();
    someStub.Stub(x => x.SomeMethod(1)).Return(ReturnVal);
    }
