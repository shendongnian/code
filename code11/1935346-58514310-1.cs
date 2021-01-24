    [TestMethod]
    public void Should_Convert_Int_To_Long() {
        var expected = typeof(long);
        var actual = ConvertValue(23, expected);
        Assert.AreEqual(expected, actual.GetType());
    }
    [TestMethod]
    public void Should_Convert_Long_To_Int() {
        var expected = typeof(int);
        var actual = ConvertValue((long)23, expected);
        Assert.AreEqual(expected, actual.GetType());
    }
    [TestMethod]
    public void Should_Convert_String_To_Long() {
        var expected = typeof(long);
        var actual = ConvertValue("23", expected);
        Assert.AreEqual(expected, actual.GetType());
    }
    [TestMethod]
    public void Should_Convert_String_To_Int() {
        var expected = typeof(int);
        var actual = ConvertValue("23", expected);
        Assert.AreEqual(expected, actual.GetType());
    }
