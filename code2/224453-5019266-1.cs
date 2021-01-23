    [Test]
    public void TestWrap()
    {
        Assert.AreEqual(2, "A B C".Wrap(4).Length);
        Assert.AreEqual(1, "A B C".Wrap(5).Length);
        Assert.AreEqual(2, "AA BB CC".Wrap(7).Length);
        Assert.AreEqual(1, "AA BB CC".Wrap(8).Length);
        Assert.AreEqual(2, "TEST TEST TEST TEST".Wrap(10).Length);
        Assert.AreEqual(2, "  TEST TEST TEST TEST  ".Wrap(10).Length);
        Assert.AreEqual("TEST TEST", "  TEST TEST TEST TEST  ".Wrap(10)[0]);
    }
