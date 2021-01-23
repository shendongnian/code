    [TestMethod]
    public void _5in_Equals_12_7cm() {
        var inches = new ImperialDistance(5);
        var cms = new MetricDistance(MetricDistance.Centimeter.ToMeters() * 12.7);
        var calcCentimeters = Math.Round(inches.ToMetricDistance().ToCentimeters(), 2, MidpointRounding.AwayFromZero);
        var calcInches = Math.Round(cms.ToImperialDistance().ToInches(), 2, MidpointRounding.AwayFromZero);
        
        Assert.AreEqual(cms.ToCentimeters(), 12.7);
        Assert.AreEqual(calcCentimeters, 12.7);
        Assert.AreEqual(inches.ToInches(), 5);
        Assert.AreEqual(calcInches, 5);
    }
