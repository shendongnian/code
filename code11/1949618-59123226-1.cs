    [Theory]
    [InlineData(BooEnum.First, BooEnum.Second, false)]
    [InlineData(BooEnum.Second, BooEnum.First, false)]
    [InlineData(BooEnum.First, BooEnum.First, true)]
    [InlineData(BooEnum.Second, BooEnum.Second, true)]
    public void AreEqual_DifferentBooEnum_ShouldReturnFalse(BooEnum first, BooEnum second, bool expected)
    {
        var firstFoo = new FooBuilder(first).Create();
        var secondFoo = new FooBuilder(second).Create();
        var actual = service.ValidateEquality(firstFoo, secondFoo);
        actual.Should().Be(expected);
    }
    
