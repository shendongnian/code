    [Test]
    public void ClassToTest_ShouldCreateFileOnInitialisation()
    {
        //You should not even need this line because of constructor chaining
        //Mock<ClassToTest> mockClass = new Mock<ClassToTest>() { CallBase = true };
        mockClass.Setup(x => x.Method1(It.IsAny<string>());
        var o = mockClass.Object;
        mockClass.Verify(x => x.Method1(@"C:\myfile.dat"));
    }
