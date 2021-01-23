    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException),
        "Service should throw an exception when called on saturday.")]
    public void DoSomething_WhenCalledOnSaturday_ThrowsException()
    {
        // Arrange
        var saturday = new DateTime(2011, 1, 1);
        Assert.AreEqual(saturday.DayOfWeek, DayOfWeek.Saturday,
            "Test setup fail");
        var clock = new FakeSystemClock() { Now = saturday };
        var service = new Service(clock);
        // Act
        service.DoSomething();
    }
