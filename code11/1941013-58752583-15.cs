    [TestMethod]
    public void CompareModels()
    {
        // Arrange
        IFileService fileService = Substitute.For<IFileService>();
        //TODO: setup fileService Dummy.
        var sut = new FileMover(fileService); // sut stands for Service Under Test.
        string sourceDir = @"C:\Test\Source";
        string destDir = @"C:\Test\Destination";
        string userInput = "abcd";
        // Act
        sut.MoveFiles(sourceDir, destDir, userInput);
        // Assert
        //TODO: test whether the fileService methods have been called as expected.
    }
