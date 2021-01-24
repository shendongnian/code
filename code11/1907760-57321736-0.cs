    [TestInitialize]
    public void TestInitialize() 
    {
        var weather = new Mock<Weather>();
        var airport = new Airport("TestAirport", weather)
    }
