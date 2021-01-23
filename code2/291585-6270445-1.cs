	public void Test1()
	{
		// A hack to call an overridden method.
		var mi = typeof(ClassUnderTest).GetMethod("MethodToTest");
		DynamicMethod dm = new DynamicMethod(
			"BaseMethodToTest",
			null,
			new Type[] { typeof(SClassUnderTest) },
			typeof(SClassUnderTest));
		ILGenerator gen = dm.GetILGenerator();
		gen.Emit(OpCodes.Ldarg_1);
		gen.Emit(OpCodes.Call, mi);
		gen.Emit(OpCodes.Ret);
		var baseMethodCall = (Action<SClassUnderTest>)dm.CreateDelegate(
			typeof(Action<SClassUnderTest>));
		// Arrange the stub.
		SClassUnderTest stub = new SClassUnderTest();
		stub.InstanceBehavior = BehavedBehaviors.NotImplemented;
		stub.MethodToTest01 = () =>
		{
			baseMethodCall(stub);
		};
		// Act.
		stub.MethodToTest();
	}
