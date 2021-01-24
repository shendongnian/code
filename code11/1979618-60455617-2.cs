    [Test]
    public void Test()
    {
        var settings = new DiagnosticsSettings { ["Today"] = "SomeValue" };
        var value = settings.GetEnumValue<CreatedOn>(CreatedOn.Today.ToString());
        Assert.AreEqual(1, value);
    }
