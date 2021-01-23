    [TestCase(double.MinValue)]
    [TestCase(double.MaxValue)]
    [TestCase(double.NaN)]
    [TestCase(double.NegativeInfinity)]
    [TestCase(double.PositiveInfinity)]
    public void WillFail(double input)
    {
        decimal result = (decimal)input; // Throws OverflowException!
    }
