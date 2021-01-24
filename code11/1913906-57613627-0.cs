    [TestMethod]
    public void Resizing_array_appends_default_values()
    {
        var dates = new DateTime[] {DateTime.Now};
        Array.Resize(ref dates, dates.Length + 1);
        Assert.AreEqual(dates.Last(), default(DateTime));
        var strings = new string[] { "x" };
        Array.Resize(ref strings, strings.Length + 1);
        Assert.IsNull(strings.Last());
        var objects = new object[] { 1, "x" };
        Array.Resize(ref objects, objects.Length + 1);
        Assert.IsNull(objects.Last());
    }
