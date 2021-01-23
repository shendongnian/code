    public SomeClassTestAdapter : SomeClass
    {
        public bool GetIsHappy(string mood)
        {
            return IsHappy(mood);
        }
    }
    [Test]
    public void ShouldReturnTrueWhenPassedHappy()
    {
        var classUnderTest = new SomeClassTestAdapter();
        bool result = classUnderTest.IsHappy("Happy");
        Assert.IsTrue(result, "Expected result to be true");
    }
    [Test]
    public void ShouldReturnFalseWhenPassedLowerCaseHappy()
    {
        var classUnderTest = new SomeClassTestAdapter();
        bool result = classUnderTest.IsHappy("happy");
        Assert.IsFalse(result, "Expected result to be false");
    }
    [Test]
    public void ShouldReturnFalseWhenPassedNull()
    {
        var classUnderTest = new SomeClassTestAdapter();
        bool result = classUnderTest.IsHappy(null);
        Assert.IsFalse(result, "Expected result to be false");
    }
