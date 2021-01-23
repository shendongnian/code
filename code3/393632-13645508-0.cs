    var mocks = new MockRepository();
    var fooMock = mocks.DynamicMock<IFoo>();
    using (mocks.Ordered())
    {
        fooMock.Expect(x => x.Method1());
        fooMock.Expect(x => x.Method2());
    }
    fooMock.Replay();
    var bar = new Bar(fooMock);
    bar.DoWork();
    fooMock.VerifyAllExpectations();
