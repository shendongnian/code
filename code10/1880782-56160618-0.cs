    [Fact]
    public void TestUsingPartialSub() {
        var anA = Substitute.ForPartsOf<A>();
        var result = anA.PublicMethod();
        Assert.True(result);
    }
