    [Test]
    public void Expect_AddCountryCall()
    { 
        var canTadd = "USA";
        var canAdd = "Canadd-a";
        // mock setup
        var mock = new Mock<IRepository>();
        mock.Setup(x => x.CanAdd(canTadd)).Returns(false);
        mock.Setup(x => x.CanAdd(canAdd)).Returns(true);
        var x = new X(mock.Object);
        // check state of x
        x.AddCountry(canTadd);
        Assert.AreEqual(0, x.Countires.Count);
        x.AddCountry(canAdd);
        Assert.AreEqual(0, x.Countires.Count);
        Assert.AreEqual(0, x.Countires.Count);
        Assert.AreEqual(canAdd, x.Countires.First());
        // check if the repository methods were called
        mock.Verify(x => x.CanAdd(canTadd));
        mock.Verify(x => x.CanAdd(canAdd));
    }   
