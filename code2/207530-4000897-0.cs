	.method public hidebysig static int32  CountNonNull<class T>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!T> enumerable) cil managed
	{
		.custom instance void [System.Core]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
		.maxstack  4
		.locals init ([0] int32 CS$1$0000)
		IL_0000:  nop
		IL_0001:  ldarg.0
		IL_0002:  ldnull
		// Push the lambda for ReferenceEquals onto the stack.
		IL_0003:  ldftn      bool ConsoleApplication7.Program::'<CountNonNull>b__8'<!!0>(!!0)
		// Create a new delegate for the lambda.
		IL_0009:  newobj     instance void class [mscorlib]System.Func`2<!!T,bool>::.ctor(object,
																						native int)
		// Call the Count Linq method.
		IL_000e:  call       int32 [System.Core]System.Linq.Enumerable::Count<!!0>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
																					class [mscorlib]System.Func`2<!!0,bool>)
		IL_0013:  stloc.0
		IL_0014:  br.s       IL_0016
		IL_0016:  ldloc.0
		IL_0017:  ret
	}
