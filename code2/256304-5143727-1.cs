	enum MyMark { LookForMe, LookForMyCaller, LookForMyCallersCaller, LookForThread }
	delegate MethodBase MyGetCurrentMethodDelegate(ref MyStackCrawlMark mark);
	static MyGetCurrentMethodDelegate dynamicMethod = null;
	static MethodBase MyGetCurrentMethod(ref MyStackCrawlMark mark)
	{
		if (dynamicMethod == null)
		{
			var m = new DynamicMethod("GetCurrentMethod",
				typeof(MethodBase),
				new Type[] { typeof(MyStackCrawlMark).MakeByRefType() },
				true //Ignore all privilege checks :D
			);
			var gen = m.GetILGenerator();
			gen.Emit(OpCodes.Ldarg_0); //NO type checking here!
			gen.Emit(OpCodes.Call,
				Type.GetType("System.Reflection.RuntimeMethodInfo", true)
					.GetMethod("InternalGetCurrentMethod",
						BindingFlags.Static | BindingFlags.NonPublic));
			gen.Emit(OpCodes.Ret);
			Interlocked.CompareExchange(ref dynamicMethod,
				(MyGetCurrentMethodDelegate)m.CreateDelegate(
					typeof(MyGetCurrentMethodDelegate)), null);
		}
		return dynamicMethod(ref mark);
	}
	[MethodImpl(MethodImplOptions.NoInlining)]
	static void Test()
	{
		var mark = MyStackCrawlMark.LookForMe; //"Me" is Test's _caller_, NOT Test
		var method = MyGetCurrentMethod(ref mark);
		Console.WriteLine(method.Name);
	}
