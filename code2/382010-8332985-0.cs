    [Test]
    public void X()
    {
        var objectList = Enumerable.Range(1, 10).Select(d => new {DecimalValue = Convert.ToDecimal(d)});
        var result = (objectList.Any()) ? objectList.Distinct().Sum(x => x.DecimalValue) : 0;
        Assert.AreEqual(55, result);
        Assert.AreEqual(typeof (decimal), result.GetType());
    }
