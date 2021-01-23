    [Flags]
	public enum TestEnum
	{
		None = 0,
		Test1 = 1,
		Test2 = 2,
		Test4 = 4
	}
    [Test]
	public void ConvertToFlagTest()
	{
		var testEnumArray = new List<TestEnum> { TestEnum.Test2, TestEnum.Test4 };
		var res = testEnumArray.ConvertToFlag();
		Assert.AreEqual(TestEnum.Test2 | TestEnum.Test4, res);
	}
