    [TestMethod]
    public void Example()
    {
      var tripBalances = new List<int> { 0, 1, -2, 3 };
      var resolver = new GasStationResolver();
      var indexOfGasStation = resolver.FindFirstStation(tripBalances);
      Assert.AreEqual(3, indexOfGasStation);
    }
