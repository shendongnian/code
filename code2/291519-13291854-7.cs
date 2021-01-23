    public static MetricDistance Centimeters(this Int32 that)
    {
        return new MetricDistance(MetricDistance.Centimeter.ToMeters() * that);
    }
    [TestMethod]
    public void _100cm_plus_300cm_equals_400cm()
    {
        Assert.AreEqual(100.Centimeters() + 300.Centimeters(), 400.Centimeters());
    }
