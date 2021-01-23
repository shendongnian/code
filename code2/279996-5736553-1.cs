    [Test]
    public void ShoudlCallMockMethod()
    {
        var mocked = new Mock<IDoStuff>();
        var target = new ClassToTest(mocked.Object);
        target.DoStuff();
        mocked.Verify(x => x.CallMyMethod(It.IsAny<string>());
    }
