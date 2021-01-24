    [Flags]
    public enum TestEnum : long
    {
        ValueNone = 0,  // You can't really "have" a Value0, it's an absence of values
        Value1 = 0x1,
        Value2 = 0x2,
        Value3 = 0x4,
        Value4 = 0x8
    }
	foreach(var enumVal in Enum.GetValues(typeof(TestEnum)))
	{
		Console.WriteLine("val is: {0} long is: {1}", enumVal, (long)enumVal);
	}
	{
		Console.WriteLine("Start with 1 and 3, remove 3 from number");
		var testEnum = TestEnum.Value1 | TestEnum.Value3;
		Console.WriteLine("testEnum is: {0}({1})", testEnum, (long)testEnum);
		long testVal = 4;   // TestEnum.Value3
		var removeEnum = (TestEnum)testVal;
		removeEnum = ~removeEnum;
		testEnum &= removeEnum;
		Console.WriteLine("testEnum is: {0}({1})", testEnum, (long)testEnum);
	}
	{
		Console.WriteLine("Start with 1, 2, 4 and remove 1 and 4 from number");
		var testEnum = TestEnum.Value1 | TestEnum.Value2 | TestEnum.Value4;
		Console.WriteLine("testEnum is: {0}({1})", testEnum, (long)testEnum);
		long testVal = (long)TestEnum.Value1 | (long)TestEnum.Value4;   // Could also have added them
		var removeEnum = (TestEnum)testVal;
		Console.WriteLine("Removing: {0}({1})", removeEnum, (long)removeEnum);
		testEnum &= ~removeEnum;
		Console.WriteLine("testEnum is: {0}({1})", testEnum, (long)testEnum);
	}
