    [Test]
    public void ClassToTest_ShouldCreateFileOnInitialisation()
    {
        Mock<ClassToTest> mockClass = new Mock<ClassToTest>();
        mockClass.Setup(x => x.Method1(It.IsAny<string>());
        var o = mockClass.Object;
        mockClass.Verify(x => x.Method1(@"C:\myfile.dat"));
    }
