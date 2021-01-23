    [Test]
    public void Linear()
    {
        const int PivotValue = 5;
        const int RangeSize = 2;
        int[] enumerable = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] range = enumerable.PivotRange(PivotValue, RangeSize).ToArray();
        CollectionAssert.AreEqual(new[] { 3, 4, 5, 6, 7 }, range);
    }
    [Test]
    public void NonLinear()
    {
        const int PivotValue = 5;
        const int RangeSize = 2;
        int[] enumerable = new[] { 0, 1, 2, 3, 4, 5, 600, 700, 800, 900, 1000 };
        int[] range = enumerable.PivotRange(PivotValue, RangeSize).ToArray();
        CollectionAssert.AreEqual(new[] { 3, 4, 5, 600, 700 }, range);
    }
    [Test]
    public void NoLeft()
    {
        const int PivotValue = 5;
        const int RangeSize = 2;
        int[] enumerable = new[] { 5, 600, 700, 800, 900, 1000 };
        int[] range = enumerable.PivotRange(PivotValue, RangeSize).ToArray();
        CollectionAssert.AreEqual(new[] { 5, 600, 700 }, range);
    }
    [Test]
    public void NoRight()
    {
        const int PivotValue = 5;
        const int RangeSize = 2;
        int[] enumerable = new[] { 0, 1, 2, 3, 4, 5 };
        int[] range = enumerable.PivotRange(PivotValue, RangeSize).ToArray();
        CollectionAssert.AreEqual(new[] { 3, 4, 5 }, range);
    }
