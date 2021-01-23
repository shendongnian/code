    [TestCase("15 °", "-10 °", 25, typeof(Degrees))]
    [TestCase("-10 °", "15 °", -25, typeof(Degrees))]
    [TestCase("-10 °", "0 °", -10, typeof(Degrees))]
    [TestCase("-90 °", "1.5707 rad", -3.1414, typeof(Radians))]
    [TestCase("1.5707 rad", "-90 °", 3.1414, typeof(Radians))]
    [TestCase("1.5707 rad", "1.5707 rad", 0, typeof(Radians))]
    public void SubtractionTest(string lvs, string rvs, double ev, Type et)
    {
        var lv = AngleUnitValue.Parse(lvs);
        var rv = AngleUnitValue.Parse(rvs);
        var diff = lv - rv;
        Assert.AreEqual(ev, diff.Value, 1e-3);
        Assert.AreEqual(et, diff.Unit.GetType());
    }
