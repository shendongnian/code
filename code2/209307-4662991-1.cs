    [Test]
    public void DoOneStep ()
    {
        var mock = new Mock<PairOfDice>();
        mock.SetupGet(x => x.Value).Returns(1);
        PairOfDice d = mock.Object;
        Assert.AreEqual(1, d.Value);
    }
