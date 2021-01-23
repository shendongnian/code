    [Test]
    public void Example()
    {
        string str = SplitAsWords("TheQuickBrownFox");
        Assert.That(str, Is.EqualTo("The quick brown fox"));
    }
