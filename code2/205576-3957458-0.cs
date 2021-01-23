    [Test]
    public void FirstOnEmptyEnumerable()
    {
        Assert.Throws<TestCustomException>(() => this.emptyEnumerable.First(new TestCustomException()));
    }
