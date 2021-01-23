    [Test]
    public void UnionTest()
    {
        var a = ImmutableHashSet.Create("A");
        var b = ImmutableHashSet.Create("B");
        var c = ImmutableHashSet.Create("C");
        var d = a.Union(b).Union(c);
        Assert.IsTrue(ImmutableHashSet.Create("A", "B", "C").SetEquals(d));
    }
