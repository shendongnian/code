    interface IFoo
    {
        void Bar();
    }
    [Test]
    public void TestBarExceptionThenSuccess()
    {
        var repository = new MockRepository(MockBehavior.Default);
        var mock = repository.Create<IFoo>();
    
        mock.Setup(m => m.Bar()).
            Callback(() => mock.Setup(m => m.Bar())). // Setup() replaces the initial one
            Throws<Exception>();                      // throw an exception the first time
        
        ...
    }
