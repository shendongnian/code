    public void DoSomethingV2WillInvokeDoWorkCorrectly()
    {
        var mock = new Mock<IMyDependency2>();
        int parameter = 60;
        mock.Setup(imd => imd.DoWork(It.Is<int>(i => i == 2 * parameter)).Verifiable();
        var sut = new MyClass2(mock.Object);
        sut.DoSomething(parameter);
        //Verify that the mock was called correctly
        mock.Verify();
    }
