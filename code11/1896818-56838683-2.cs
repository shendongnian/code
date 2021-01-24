    [TestMethod]
    public void TheRightWay()
    {
        // this is what you want to check
        var implements = typeof(IVehicle).IsAssignableFrom(typeof(Car));
        var inherits = typeof(VehicleBase).IsAssignableFrom(typeof(Car));
        Assert.IsTrue(implements);
        Assert.IsTrue(inherits);
    }
