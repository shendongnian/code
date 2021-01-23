    [TestMethod]
    public void StackOverflowQuestion()
    {
        var input = "0123457";
        var temp = Regex.Replace(input, @"(.{2})", "$1 ");
        Assert.AreEqual("01 23 45 7", temp);
    }
