    [TestMethod]
    public void LineBreakCounter_ShouldFindLineBreaks()
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
        Assert.AreEqual(3, counter.Lines);
        Assert.AreEqual(0, counter.GetOffset(0));
        Assert.AreEqual(6, counter.GetOffset(1));
        Assert.AreEqual(14, counter.GetOffset(2));
    }
