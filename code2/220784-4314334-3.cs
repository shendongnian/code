    public void DoSomethingWillInvokeDoWorkCorrectly()
    {
        var mock = new Mock<IMyDependency>();
        mock.Setup(imd => imd.DoWork()).Verifiable();
        var sut = new MyClass(mock.Object);
        sut.DoSomething();
        //Verify that the mock was called correctly
        mock.Verify();
    }
