    [SetUp]
    public void SetUp()
    {
        _fakeDirectoryWrapper = new Mock<IDirectory>();
        // setup GetFiles
        _fakeDirectoryWrapper.Setup(_ => _.GetFiles(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new[] { "a.txt", "b.txt" });
        // setup other methods...
    }
