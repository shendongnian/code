    var fooMock = MockRepository.GenerateMock<IFoo>();
    using (fooMock.GetMockRepository().Ordered())
    {
        fooMock.Expect(x => x.Method1());
        fooMock.Expect(x => x.Method2());
    }
    
    var bar = new Bar(fooMock);
    bar.DoWork();
    
    fooMock.VerifyAllExpectations();
