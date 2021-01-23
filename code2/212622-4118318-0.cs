    [Fact(DisplayName = "Test Primitive count limit"), Isolated]
    public void TestPrimitiveCountLimit()
    {
        Primitive._previousId = int.MaxValue;
        Assert.Throws<OverflowException>(() => 
            Isolate.Fake.Instance<Primitive>(Members.CallOriginal, ConstructorWillBe.Called));
    }
