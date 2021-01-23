    [TestMethod]
    public void LineBreakCounter_ShouldFindLine()
    {
        var text = "Hello\nWorld!\r\n";
        var counter = new LineBreakCounter(text);
        Assert.AreEqual(0, counter.GetLine(0));
        Assert.AreEqual(0, counter.GetLine(3));
        Assert.AreEqual(0, counter.GetLine(5));
        Assert.AreEqual(1, counter.GetLine(6));
        Assert.AreEqual(1, counter.GetLine(8));
        Assert.AreEqual(1, counter.GetLine(12));
        Assert.AreEqual(1, counter.GetLine(13));
        Assert.AreEqual(2, counter.GetLine(14));
    }
