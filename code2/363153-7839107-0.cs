    [Test]
    public void SO()
    {
        var testing = new Testing();
        Assert.AreEqual(0, testing.RedBalls);
        Assert.AreEqual(0, testing.BlueBalls);
        Assert.AreEqual(0, testing.TotalBalls);
        testing.RedBalls = 2;
        testing.BlueBalls = 4;
        Assert.AreEqual(2, testing.RedBalls);
        Assert.AreEqual(4, testing.BlueBalls);
        Assert.AreEqual(6, testing.TotalBalls);
    }
    class Testing
    {
        public int RedBalls { get; set; }
        public int BlueBalls { get; set; }
        public int TotalBalls { get { return RedBalls + BlueBalls; } }
    }
