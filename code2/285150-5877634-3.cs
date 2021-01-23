	using System;
	using System.Reflection.Emit;
	static class Program
	{
		delegate uint UintOpDelegate(uint a, uint b);
		static void Main()
		{
			var method = new DynamicMethod("Multiply",
				typeof(uint), new Type[] { typeof(uint), typeof(uint) });
			var gen = method.GetILGenerator();
			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Ldarg_1);
			gen.Emit(OpCodes.Mul);
			gen.Emit(OpCodes.Ret);
			var del = (UintOpDelegate)method.CreateDelegate(typeof(UintOpDelegate));
			var product = del(2, 3); //product is now 6!
		}
	}
