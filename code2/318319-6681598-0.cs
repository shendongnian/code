    [Test]
    public void SO6680770()
    {
        var cols = new[] { "apples", "pears", "bananas" };
    
        var csv = string.Join(", ", cols.Select(s => string.Concat("'", s, "'")));
    
        Assert.AreEqual("'apples', 'pears', 'bananas'", csv);
    }
