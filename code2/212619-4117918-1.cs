    [Fact(DisplayName = "Test Primitive count limit")]
    public void TestPrimitiveCountLimit()
    {
        Assert.Throws(typeof(OverflowException), delegate()
        {
            var generator = new PrimitiveIDGenerator();
            for (; ; )
            {
                generator.GetNext();
            }
        });
    }
