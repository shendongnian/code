    [Fact]
    public void TestDelegate() {
        byte[] data = new byte[0];
        var result = ClassUnderTest.Dep_OnGetData("hi", ref data);
        Assert.True(result);
        Assert.Equal(new byte[] { 104, 105 }, data);
    }
    [Fact]
    public void TestWireup() {
        var sub = Substitute.For<ISomeType>();
        var subject = new ClassUnderTest(sub);
        sub.Received().OnGetData += ClassUnderTest.Dep_OnGetData;
    }
