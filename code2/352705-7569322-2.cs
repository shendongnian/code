	static A GetADynamic(dynamic item)
	{
		return new B();
	}
	...
	dynamic test = "Test";
	var a = GetADynamic(test); // whole expression is dynamic
	var a2 = GetADynamic((string)test); // whole expression is not dynamic, and a2 has a static type of `A`
	
