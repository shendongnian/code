    [Test, Sequential]
    public void TestDivisionBy2(
        [Values(10, 25, 40)] int input,
        [Values(5, 12, 20)] int expectedOutput)
    {
        Assert.AreEqual(expectedOutput, input / 2);
    }
