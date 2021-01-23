    [TestCase(120000, -1)]
    [TestCase(Int32.MinValue, Int32.MaxValue)]
    [TestCase(-1, 23333)]
    public void ShouldHandleWrongRangeValues(int n, int d)
    {
         Assert.DoesNotThrow(() => { var someIntermediateValue = n * d; });
    }
